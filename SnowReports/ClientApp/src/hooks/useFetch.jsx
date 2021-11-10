import React, {useState, useEffect} from 'react';

export const useFetchJson = (url, jsonHandler) =>{

    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState("")
    const [results, setResults] = useState([])

    const fetching = async() =>
    {
        try{
            console.log("useFetchingV2 for "+url);
            setIsLoading(true);
            const response = await fetch(url);
            const json = await response.json();

            if (jsonHandler==undefined)
            {
                console.log("useFetchingV2 jsonHandler undefined")
                setResults(json);
            }
            else
            {
                console.log("useFetchingV2 jsonHandler NOT undefined")
                const result = await jsonHandler(json);
                setResults(result);
            }
        }
        catch (e) {
            setError(e.memberName);
        }
        finally {
            setIsLoading(false);
        }
    }

    useEffect(()=>fetching(),[]);

    return [results, setResults,isLoading, error];
}