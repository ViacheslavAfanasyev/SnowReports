import React, {useContext, useEffect, useState} from 'react';
import DropDownFilter from "./DropDownFilter/DropDownFilter";
import {ReportFiltersContext} from "../../context/ReportFiltersContext";
import Extensions from "../../services/Extensions";

const SystemFilters = () => {

    const {setTicketsLevel, setTimeZoneOffsetInHours, setMinutesInterval}= useContext(ReportFiltersContext)

    const [timezonesList, setTimezonesList] = useState([]);
    const [ticketsLevelsList, setTicketsLevelsList] = useState([]);
    const [minutesIntervalList, setMinutesIntervalList] = useState([]);


    /*
    useEffect(()=> setMinutesIntervalList([5,15,30,60,120,180,300]),[]);
    useEffect(()=> setTicketsLevelsList(['L1', 'L2']),[]);
    useEffect(()=> setTimezonesList(Extensions.GetTimeZones()),[]);
*/
    //NEED TO FIX. ASYNC SETTING STATE OVERIDES PROPS OF THE OBJECT
    //DropDownFilter bellow are loaded and invoke setState(setSelectedValue) very fast
        useEffect(()=>{
            setTimeout(()=>setMinutesIntervalList([5,15,30,60,120,180,300]),30)
            setTimeout(()=>setTicketsLevelsList(['L1', 'L2']),50)
            setTimeout(()=>setTimezonesList(Extensions.GetTimeZones()),70)
        },[])

    return (
        <ul>
            <li>
                <DropDownFilter setSelectedValue={setTimeZoneOffsetInHours} source={timezonesList} name={"TimeZone"} />
            </li>
            <li>
                <DropDownFilter setSelectedValue={setTicketsLevel} source={ticketsLevelsList} name={"Levels"} />
            </li>
            <li>
                <span>Interval(mins)</span><DropDownFilter setSelectedValue={setMinutesInterval} source={minutesIntervalList} name={"Interval"} />
            </li>

        </ul>
    );
};

export default SystemFilters;