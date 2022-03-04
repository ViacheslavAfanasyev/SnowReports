import React, {useState, useEffect } from 'react';
import {ReportFiltersContext} from '../../context/ReportFiltersContext'
import TicketsNumberChart from "./TicketsNumberChart";
import ReportFilters from "../ReportFilters/ReportFilters";
import styles from './TicketsNumberReport.module.css'
import {useFetching} from "../../hooks/useFetch";
import SnowServices from "../../services/SnowServices";
import SnowDatePicker from "../ReportFilters/SnowDatePicker/SnowDatePicker";
import {useDynamicQueryString} from "../../hooks/useDynamicQueryString";

const TicketsNumberReport = () => {

    const [chartData, setChartData] = useState([]);
    const [chartLines, setChartLines] = useState([]);
    //const [queryString, setQueryString] = useState("");
    const [displayCombinedGraph, setDisplayCombinedGraph] = useState(false);

    const [queryString, setDate, setAssignmentGroup,setTicketsLevel, setTimeZoneOffsetInHours, setMinutesInterval]= useDynamicQueryString();


    const [fetchData,isLoading,error] = useFetching(async () => {
        const data = await SnowServices.GetTicketsReportData(queryString);
        setChartData(data);
    })

    useEffect(fetchData, [queryString])

    const setAllowCombineCheckboxes =(checked)=>
    {
        setDisplayCombinedGraph(checked);
    }

    return(
        <ReportFiltersContext.Provider value={{chartData, chartLines, setChartLines, setAssignmentGroup,setTicketsLevel, setTimeZoneOffsetInHours, setMinutesInterval, setAllowCombineCheckboxes, displayCombinedGraph}}>

         {/*   {error!=''?<div className="alert alert-danger">{error}</div>:<div></div>}
            {isLoading?<div className="alert alert-primary">Loading...</div>:<div className="alert alert-success">Loaded</div>}*/}

            <div id={styles.LeftBlock}>
            <ReportFilters />
            </div>
            <div id={styles.RightBlock}>
                <SnowDatePicker setDate={setDate} />
                <TicketsNumberChart />
            </div>
        </ReportFiltersContext.Provider>
    );
};




export default TicketsNumberReport;