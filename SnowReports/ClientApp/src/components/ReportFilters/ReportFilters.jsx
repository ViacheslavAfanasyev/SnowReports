import React, {useContext, useEffect, useState} from 'react';
import CheckboxesList from "./CheckBoxList/CheckboxesList";
import SnowDatePicker from "./SnowDatePicker/SnowDatePicker";
import styles from './ReportFilters.module.css'
import DropDownFilter from "./DropDownFilter/DropDownFilter";
import {useFetching, useFetchJson} from "../../hooks/useFetch"
import {useDynamicQueryString} from "../../hooks/useDynamicQueryString"
import {ReportFiltersContext} from "../../context/ReportFiltersContext";
import SnowServices from "../../services/SnowServices";
import Extensions from "../../services/Extensions";

const assignmentGroupsUrl = process.env.REACT_APP_SNOW_HOST+'/api/snowreports/AccumulatedAssignmentGroups';
const ticketStateUrl = process.env.REACT_APP_SNOW_HOST+'/api/SnowReports/States';

/*const CreateStatesList = (json) =>
{
    console.log("CreateStatesList for "+json)
    const result = [];
    Object.keys(json).forEach(key => result.push({key: key, value: json[key], checked: false}))
    result[0].checked = true;
    return result;
}*/

const ReportFilters = () => {

    //Restore ReportFiltersContext
    const {setChartLines, setQueryString}= useContext(ReportFiltersContext)

    //Create states
    const [assignmentGroupsList, setAssignmentGroupsList ] = useState([])
    const [statesList, setStatesList] = useState([])
    const [timezonesList, setTimezonesList] = useState([])

        //Define fetching functions to get the data
    const [fetchAssigmentGroups,assigmentGroupsIsLoading,assigmentGroupsError] = useFetching(async ()=>{
        const data = await SnowServices.GetAssigmentGroups(false);
        setAssignmentGroupsList(data);
    })

   const [fetchTicketStates,ticketStatesIsLoading,ticketStatesError] = useFetching(async ()=>{
        const data = await SnowServices.GetTicketStates(true);
        setStatesList(data);
    })

    Extensions.GetTimeZones();
    //Create dynamic query string
    const [queryString, setDate, setAssignmentGroup, setTimeZoneOffsetInHours]= useDynamicQueryString();

    //Define execution of the functions
    useEffect(()=>{
        fetchAssigmentGroups();
        fetchTicketStates();
        setTimezonesList(Extensions.GetTimeZones());
    },[]);
    useEffect(()=>setQueryString(queryString), [queryString]);
    useEffect(()=>setChartLines(statesList),[statesList])


    return (
         <ul className={styles.ReportFiltersList} >
          <li>
                <CheckboxesList setSelectedValue={setStatesList} source={statesList} name={"States"} />
            </li>
            <li>
                <DropDownFilter setSelectedValue={setAssignmentGroup} source={assignmentGroupsList} name={"AssigmentGroups"} />
            </li>
             <li>
                 <DropDownFilter setSelectedValue={setTimeZoneOffsetInHours} source={timezonesList} name={"TimeZone"} />
             </li>

            <li className={styles.Right}>
                <SnowDatePicker setDate={setDate} />
            </li>
        </ul>
    );
};

export default ReportFilters;