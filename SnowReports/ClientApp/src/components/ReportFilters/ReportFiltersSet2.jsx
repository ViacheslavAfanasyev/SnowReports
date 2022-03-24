import React, {useContext, useEffect, useState} from 'react';
import {ReportFiltersContext} from "../../context/ReportFiltersContext";
import {useFetching} from "../../hooks/useFetch";
import SnowServices from "../../services/SnowServices";
import Extensions from "../../services/Extensions";
import styles from "./ReportFiltersSet1.module.css";
import CheckboxesList from "./CheckBoxList/CheckboxesList";
import DropDownFilter from "./DropDownFilter/DropDownFilter";
import SystemFilters from "./SystemFilters";
import ToggleButton from "../UI/ToggleButton"

const ReportFiltersSet2 = () => {
    const reportFiltersName = "_byRegion"
    //Restore ReportFiltersContext
    const {setChartLines, setAllowCombineCheckboxes, setAssignmentGroup, setState}= useContext(ReportFiltersContext)

    //Create states
    const [assignmentGroupsList, setAssignmentGroupsList ] = useState([])
    const [fullAssignmentGroupsList, setFullAssignmentGroupsList ] = useState([])
    const [shortAssignmentGroupsList, setShortAssignmentGroupsList ] = useState([])
    const [checkboxReportName, setCheckboxReportName ] = useState([])


    const [statesList, setStatesList] = useState([])

    //Define fetching functions to get the data
    const [fetchAssigmentGroups,assigmentGroupsIsLoading,assigmentGroupsError] = useFetching(async ()=>{
        const assigmentGroups = await SnowServices.GetAssigmentGroups(true);
        const regions = await SnowServices.GetRegions(true);
        setAssignmentGroupsList(assigmentGroups);
        setFullAssignmentGroupsList(assigmentGroups);

        setShortAssignmentGroupsList(regions);

    })



    const [fetchTicketStates,ticketStatesIsLoading,ticketStatesError] = useFetching(async ()=>{
        const data = await SnowServices.GetTicketStates(false);
        setStatesList(data);
    })

    //Define execution of the functions
    useEffect(()=>{
        fetchAssigmentGroups();
        fetchTicketStates();
        OnChangeToggleButton(false);
    },[]);

    //useEffect(()=>setChartLines(statesList),[statesList])

    function OnChangeToggleButton(checked)
    {
        if (checked)
        {
            setAssignmentGroupsList(shortAssignmentGroupsList);
            setCheckboxReportName("short")
        }
        else
        {
            setAssignmentGroupsList(fullAssignmentGroupsList);
            setCheckboxReportName("full")
        }
    }

    useEffect(()=>
    {

        setChartLines(assignmentGroupsList)
    },[assignmentGroupsList])

    return (
        <div id={styles.FiltersBlock}>
            <ul className={styles.ReportFiltersList} >
                <li>
                    <ToggleButton defaultChecked={false} onChange={OnChangeToggleButton} />
                    <CheckboxesList setSelectedValue={setAssignmentGroupsList} setAllowCombineCheckboxes={setAllowCombineCheckboxes}
                                    source={assignmentGroupsList}
                                    valuePropName='value'
                                    labelPropName='value' name={"AssigmentGroups"+reportFiltersName+"_"+checkboxReportName} />
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