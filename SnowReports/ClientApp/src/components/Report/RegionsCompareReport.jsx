import React, {useEffect, useState} from 'react';
import {useDynamicQueryString} from "../../hooks/useDynamicQueryString";
import {useFetching} from "../../hooks/useFetch";
import SnowServices from "../../services/SnowServices";
import {ReportFiltersContext} from "../../context/ReportFiltersContext";
import styles from "./StatesCompareReport.module.css";
import ReportFiltersSet2 from "../ReportFilters/ReportFiltersSet2";
import SnowDatePicker from "../ReportFilters/SnowDatePicker/SnowDatePicker";
import TicketsNumberChartByState from "./TicketsNumberChartByState";

const RegionsCompareReport = () => {
    const [chartData, setChartData] = useState([]);
    const [chartLines, setChartLines] = useState([]);
    //const [queryString, setQueryString] = useState("");
    const [displayCombinedGraph, setDisplayCombinedGraph] = useState(false);

    const [queryString, setDate, setAssignmentGroup, setState, setTicketsLevel, setTimeZoneOffsetInHours, setMinutesInterval]= useDynamicQueryString();


    const [fetchData,isLoading,error] = useFetching(async () => {
        const data = await SnowServices.GetRegionsComparedReportData(queryString);
        setChartData(data);
    })

    useEffect(fetchData, [queryString])

    const setAllowCombineCheckboxes =(checked)=>
    {
        setDisplayCombinedGraph(checked);
    }

    return(
        <ReportFiltersContext.Provider value={{chartData, chartLines, setChartLines, setAssignmentGroup, setState, setTicketsLevel, setTimeZoneOffsetInHours, setMinutesInterval, setAllowCombineCheckboxes, displayCombinedGraph}}>

            <div id={styles.LeftBlock}>
                <ReportFiltersSet2 />
            </div>
            <div id={styles.RightBlock}>
                <SnowDatePicker setDate={setDate} />
                {/* <TicketsNumberChartByState /> */}
            </div>
        </ReportFiltersContext.Provider>
    );
};

export default RegionsCompareReport;