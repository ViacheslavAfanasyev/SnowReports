import React, {useContext, useEffect, useState} from 'react';
import CheckboxesList from "./CheckBoxList/CheckboxesList";
import styles from './ReportFiltersSet1.module.css'
import DropDownFilter from "./DropDownFilter/DropDownFilter";
import {useFetching} from "../../hooks/useFetch"
import {ReportFiltersContext} from "../../context/ReportFiltersContext";
import SnowServices from "../../services/SnowServices";
import SystemFilters from "./SystemFilters";

const ReportFiltersSet1 = () => {

    const reportFiltersName = "_byState"
    //Restore ReportFiltersContext
    const {setChartLines, setAllowCombineCheckboxes, setAssignmentGroup}= useContext(ReportFiltersContext)

    //Create states
    const [assignmentGroupsList, setAssignmentGroupsList ] = useState([])
    const [statesList, setStatesList] = useState([])

    const [fetchAssigmentGroups,assigmentGroupsIsLoading,assigmentGroupsError] = useFetching(async ()=>{
        const data = await SnowServices.GetAssigmentGroups(false);
        setAssignmentGroupsList(data);
    })

   const [fetchTicketStates,ticketStatesIsLoading,ticketStatesError] = useFetching(async ()=>{
        const data = await SnowServices.GetTicketStates(true);
        setStatesList(data);
    })

    useEffect(()=>{
        fetchAssigmentGroups();
        fetchTicketStates();
    },[]);

    useEffect(()=>setChartLines(statesList),[statesList])

    return (
        <div id={styles.FiltersBlock}>
         <ul className={styles.ReportFiltersList} >
          <li>
            <CheckboxesList setSelectedValue={setStatesList} setAllowCombineCheckboxes={setAllowCombineCheckboxes} source={statesList} name={"States"+reportFiltersName} />
          </li>
          <li>
            <DropDownFilter setSelectedValue={setAssignmentGroup} source={assignmentGroupsList} name={"AssigmentGroups"+reportFiltersName} />
          </li>
         </ul>
         <SystemFilters />
        </div>
    );
};

export default ReportFiltersSet1;