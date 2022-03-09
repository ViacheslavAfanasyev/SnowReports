import React, {useContext, useEffect, useState} from 'react';
import {ReportFiltersContext} from "../../context/ReportFiltersContext";
import {useFetching} from "../../hooks/useFetch";
import SnowServices from "../../services/SnowServices";
import Extensions from "../../services/Extensions";
import styles from "./ReportFiltersSet1.module.css";
import CheckboxesList from "./CheckBoxList/CheckboxesList";
import DropDownFilter from "./DropDownFilter/DropDownFilter";
import SystemFilters from "./SystemFilters";

const ReportFiltersSet2 = () => {
    const reportFiltersName = "_byRegion"
    //Restore ReportFiltersContext
    const {setChartLines, setAllowCombineCheckboxes, setAssignmentGroup, setState}= useContext(ReportFiltersContext)

    //Create states
    const [assignmentGroupsList, setAssignmentGroupsList ] = useState([])
    const [statesList, setStatesList] = useState([])

    //Define fetching functions to get the data
    const [fetchAssigmentGroups,assigmentGroupsIsLoading,assigmentGroupsError] = useFetching(async ()=>{
        const data = await SnowServices.GetAssigmentGroups(true);
        setAssignmentGroupsList(data);
    })

    const [fetchTicketStates,ticketStatesIsLoading,ticketStatesError] = useFetching(async ()=>{
        const data = await SnowServices.GetTicketStates(false);
        setStatesList(data);
    })

    //Define execution of the functions
    useEffect(()=>{
        fetchAssigmentGroups();
        fetchTicketStates();
    },[]);

    //useEffect(()=>setChartLines(statesList),[statesList])

    return (
        <div id={styles.FiltersBlock}>
            <ul className={styles.ReportFiltersList} >
                <li>
                    <CheckboxesList setSelectedValue={setAssignmentGroup} setAllowCombineCheckboxes={setAllowCombineCheckboxes} source={assignmentGroupsList} name={"AssigmentGroups"+reportFiltersName} />
                </li>
                <li>
                    <DropDownFilter setSelectedValue={setState} source={statesList} name={"States"+reportFiltersName} />
                </li>
            </ul>
            <SystemFilters />
        </div>
    );
};

export default ReportFiltersSet2;