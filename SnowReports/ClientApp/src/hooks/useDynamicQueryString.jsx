import React, {useState, useEffect} from 'react';

export const useDynamicQueryString = () =>{

    const [urlParameters, setUrlParameters] = useState(
        {
            startDate:"",
            endDate:"",
            assigmentGroup:"",
            ticketsLevel:"",
            state:"",
            timeZoneOffsetInHours:null,
            minutesInterval:null,
        });

    const setAssignmentGroup = (assigmentGroup) =>
    {
        setUrlParameters({...urlParameters, assigmentGroup : assigmentGroup});
    }

    const setState = (state) =>
    {
        setUrlParameters({...urlParameters, state : state});
    }

    const setTimeZoneOffsetInHours = (offset) =>
    {
        setUrlParameters({...urlParameters, timeZoneOffsetInHours : offset});
    }

    function setDate(value)
    {
        let local = "en-ca"
        setUrlParameters({...urlParameters, startDate : value.startDate.toLocaleDateString(local).slice(0,10), endDate : value.endDate.toLocaleDateString(local).slice(0,10) });
    }

    function setTicketsLevel(level)
    {
        setUrlParameters({...urlParameters, ticketsLevel : level});
    }

    const setMinutesInterval = (minutesInterval) =>
    {
        setUrlParameters({...urlParameters, minutesInterval : minutesInterval});
    }

    const [queryString, setQueryString] = useState("");

    useEffect(()=>{
        setQueryString("?"+new URLSearchParams(urlParameters).toString())
    },[urlParameters]);


    return [queryString, setDate, setAssignmentGroup, setState, setTicketsLevel, setTimeZoneOffsetInHours, setMinutesInterval];

}