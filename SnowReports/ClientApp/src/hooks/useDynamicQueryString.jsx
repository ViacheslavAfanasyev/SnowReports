import React, {useState, useEffect} from 'react';

export const useDynamicQueryString = () =>{

    console.log("Query string -  SET INITIALE USE STATE");
    const [urlParameters, setUrlParameters] = useState(
        {
            startDate:"",//weekAgo.toJSON().slice(0,10),
            endDate:"",//new Date().toJSON().slice(0,10),
            assigmentGroup:"",
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
        let parameters = {...urlParameters, startDate : value.startDate.toJSON().slice(0,10), endDate : value.endDate.toJSON().slice(0,10) };
        setUrlParameters(parameters);

        console.log("Query string - "+value.startDate.toJSON().slice(0,10) + " "+ value.endDate.toJSON().slice(0,10));
    }

    const [queryString, setQueryString] = useState("");

    useEffect(()=>{
        console.log("Query string - "+urlParameters);

        setQueryString("?"+new URLSearchParams(urlParameters).toString())

    },[urlParameters]);


    return [queryString, setDate, setAssignmentGroup, setTimeZoneOffsetInHours];

}

//setRequestUrl(process.env.REACT_APP_SNOW_HOST+"/api/snowreports/GetRangedDate?"+queryStringParameters)