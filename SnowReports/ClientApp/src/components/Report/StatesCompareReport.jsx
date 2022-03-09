import React, {useState, useEffect } from 'react';
import {ReportFiltersContext} from '../../context/ReportFiltersContext'
import TicketsNumberChartByState from "./TicketsNumberChartByState";
import ReportFiltersSet1 from "../ReportFilters/ReportFiltersSet1";
import styles from './StatesCompareReport.module.css'
import {useFetching} from "../../hooks/useFetch";
import SnowServices from "../../services/SnowServices";
import SnowDatePicker from "../ReportFilters/SnowDatePicker/SnowDatePicker";
import {useDynamicQueryString} from "../../hooks/useDynamicQueryString";

const StatesCompareReport = () => {

    const [chartData, setChartData] = useState([]);
    const [chartLines, setChartLines] = useState([]);
    //const [queryString, setQueryString] = useState("");
    const [displayCombinedGraph, setDisplayCombinedGraph] = useState(false);

    const [queryString, setDate, setAssignmentGroup, setState, setTicketsLevel, setTimeZoneOffsetInHours, setMinutesInterval]= useDynamicQueryString();


    const [fetchData,isLoading,error] = useFetching(async () => {
        const data = await SnowServices.GetStatesComparedReportData(queryString);
        setChartData(data);
    })

    useEffect(fetchData, [queryString])

    const setAllowCombineCheckboxes =(checked)=>
    {
        setDisplayCombinedGraph(checked);
    }

    return(
        <ReportFiltersContext.Provider value={{chartData, chartLines, setChartLines, setAssignmentGroup,setTicketsLevel, setTimeZoneOffsetInHours, setMinutesInterval, setAllowCombineCheckboxes, displayCombinedGraph}}>

            <div id={styles.LeftBlock}>
            <ReportFiltersSet1 />
            </div>
            <div id={styles.RightBlock}>
                <SnowDatePicker setDate={setDate} />
                  <TicketsNumberChartByState />
            </div>
        </ReportFiltersContext.Provider>
    );
};




export default StatesCompareReport;