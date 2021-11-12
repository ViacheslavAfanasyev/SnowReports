import React, {useState, useEffect} from 'react';

export const useFetchJson = (url, jsonHandler) =>{

    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState("")
    const [results, setResults] = useState([])

    const fetching = async() =>
    {
        try{
            setIsLoading(true);
            const response = await fetch(url);
            const json = await response.json();

            if (jsonHandler==undefined)
            {
                //console.log("useFetchingV2 jsonHandler undefined")
                setResults(json);
            }
            else
            {
                //console.log("useFetchingV2 jsonHandler NOT undefined")
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

export const useJsonFetching = (callback, jsonHandler) =>
{

    const [fetching,isLoading,error] = useFetching(callback)

    const jsonFetching = async ()=>{
        const results = await fetching().then(r => jsonHandler(r));
    }

    return [jsonFetching,isLoading,error]
}


export const useFetching = (callback) =>
{
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState('');

    const fetching = async () =>
    {
        try {
            setIsLoading(true);
            await callback();
        }
        catch (e) {
            setError(e.message);
        }
        finally {
            setIsLoading(false);
        }

    }

    return [fetching,isLoading,error]
}