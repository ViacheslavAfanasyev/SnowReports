import React, {useState, useEffect} from 'react';

export const useDynamicQueryString = () =>{

    const [urlParameters, setUrlParameters] = useState(
        {
            startDate:"",//weekAgo.toJSON().slice(0,10),
            endDate:"",//new Date().toJSON().slice(0,10),
            assigmentGroup:"",
            ticketsLevel:"",
            timeZoneOffsetInHours:0
        });


    const setAssignmentGroup = (assigmentGroup) =>
    {
        let parameters = {...urlParameters, assigmentGroup : assigmentGroup};
        setUrlParameters(parameters);
    }

    const setTimeZoneOffsetInHours = (offset) =>
    {
        let parameters = {...urlParameters, timeZoneOffsetInHours : offset};
        setUrlParameters(parameters);
    }

    function setDate(value)
    {
        //console.log("SET DATE - "+value.startDate.toLocaleString().slice(0,10) + " "+value.startDate.toLocaleDateString().slice(0,10));
        let parameters = {...urlParameters, startDate : value.startDate.toLocaleDateString().slice(0,10), endDate : value.endDate.toLocaleDateString().slice(0,10) };
        setUrlParameters(parameters);
    }

    function setTicketsLevel(value)
    {
        let parameters = {...urlParameters, ticketsLevel : value};
        setUrlParameters(parameters);
    }

    const [queryString, setQueryString] = useState("");

    useEffect(()=>{
        setQueryString("?"+new URLSearchParams(urlParameters).toString())

    },[urlParameters]);


    return [queryString, setDate, setAssignmentGroup,setTicketsLevel, setTimeZoneOffsetInHours];

}

//setRequestUrl(process.env.REACT_APP_SNOW_HOST+"/api/snowreports/GetRangedDate?"+queryStringParameters)