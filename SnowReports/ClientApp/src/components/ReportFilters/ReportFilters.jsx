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

    const reportFiltersName = "_byState"
    //Restore ReportFiltersContext
    const {setChartLines, setAllowCombineCheckboxes, setAssignmentGroup,setTicketsLevel, setTimeZoneOffsetInHours}= useContext(ReportFiltersContext)

    //Create states
    const [assignmentGroupsList, setAssignmentGroupsList ] = useState([])
    const [statesList, setStatesList] = useState([])
    const [timezonesList, setTimezonesList] = useState([])
    const [ticketsLevelsList, setTicketsLevelsList] = useState([])

        //Define fetching functions to get the data
    const [fetchAssigmentGroups,assigmentGroupsIsLoading,assigmentGroupsError] = useFetching(async ()=>{
        const data = await SnowServices.GetAssigmentGroups(false);
        setAssignmentGroupsList(data);
    })

   const [fetchTicketStates,ticketStatesIsLoading,ticketStatesError] = useFetching(async ()=>{
        const data = await SnowServices.GetTicketStates(true);
        setStatesList(data);
    })

    const [fetchTicketsLevels,ticketLevelsIsLoading,ticketLevelsError] = useFetching(async ()=>{
        const data = await SnowServices.GetTicketsLevels(false);
        setTicketsLevelsList(data);
    })

    //Create dynamic query string
/*
    const [queryString, setDate, setAssignmentGroup,setTicketsLevel, setTimeZoneOffsetInHours]= useDynamicQueryString();
*/

    //Define execution of the functions
    useEffect(()=>{
        fetchAssigmentGroups();
        fetchTicketStates();
        setTimezonesList(Extensions.GetTimeZones());
        fetchTicketsLevels();
    },[]);
    //useEffect(()=>setQueryString(queryString), [queryString]);
    useEffect(()=>setChartLines(statesList),[statesList])

    //chartData, setChartData

    return (
        <div id={styles.FiltersBlock}>
         <ul className={styles.ReportFiltersList} >
          <li>
                <CheckboxesList setSelectedValue={setStatesList} setAllowCombineCheckboxes={setAllowCombineCheckboxes} source={statesList} name={"States"+reportFiltersName} />
            </li>
            <li>
                <DropDownFilter setSelectedValue={setAssignmentGroup} source={assignmentGroupsList} name={"AssigmentGroups"+reportFiltersName} />
            </li>
             <li>
                 <DropDownFilter setSelectedValue={setTimeZoneOffsetInHours} source={timezonesList} name={"TimeZone"+reportFiltersName} />
             </li>
             <li>
                 <DropDownFilter setSelectedValue={setTicketsLevel} source={ticketsLevelsList} name={"Levels"+reportFiltersName} />
             </li>
         </ul></div>

    );
};

export default ReportFilters;