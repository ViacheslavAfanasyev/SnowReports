import React, {useContext, useEffect, useState} from 'react';
import CheckboxesList from "./CheckBoxList/CheckboxesList";
import SnowDatePicker from "./SnowDatePicker/SnowDatePicker";
import styles from './ReportFilters.module.css'
import DropDownFilter from "./DropDownFilter/DropDownFilter";
import {useFetchJson} from "../../hooks/useFetch"
import {useDynamicQueryString} from "../../hooks/useDynamicQueryString"
import {ReportFiltersContext} from "../../context/ReportFiltersContext";

const assignmentGroupsUrl = process.env.REACT_APP_SNOW_HOST+'/api/snowreports/AccumulatedAssignmentGroups';
const ticketStateUrl = process.env.REACT_APP_SNOW_HOST+'/api/SnowReports/States';

const CreateStatesList = (json) =>
{
    console.log("CreateStatesList for "+json)
    const result = [];
    Object.keys(json).forEach(key => result.push({key: key, value: json[key], checked: false}))
    result[0].checked = true;
    return result;
}

const ReportFilters = () => {

    const {setChartLines, setQueryString}= useContext(ReportFiltersContext)

    const [assignmentGroupsList, setAssignmentGroupsList, assignmentGroupsIsLoading, assignmentGroupsLoadinError] = useFetchJson(assignmentGroupsUrl)
    const [statesList, setStatesList, statesIsLoading, statesLoadingError] = useFetchJson(ticketStateUrl,CreateStatesList);
    const [queryString, setDate, setAssignmentGroup, setTimeZoneOffsetInHours]= useDynamicQueryString();


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
            <li className={styles.Right}>
                <SnowDatePicker setDate={setDate} />
            </li>

        </ul>
    );
};

export default ReportFilters;