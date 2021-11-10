import React, {useState, useEffect} from 'react';
import DropDownElement from "./DropDownElement";


const DropDownFilter = ({setSelectedValue, source, name}) => {

    const [value, setValue] = useState(source[0]);

    useEffect(()=>{

        console.log("useEffect of DropDownFilter"+value)
        if (source!=undefined && source[0]!=undefined)
        {
            console.log("useEffect of DropDownFilter SET"+value)
            setSelectedValue(source[0])
        }

    },[source])

    function SelectionChange(e)
    {
        setSelectedValue(e.target.value);
        setValue(e.target.value);
    }

    if (source==null || source == undefined)
    {
        console.log("DropDownFilter component | source variable is null or undefined");
        return <div></div>
    }

    if (!Array.isArray(source))
    {
        console.log("DropDownFilter component | source is not an array");
        return  <div></div>
    }

    return (
        <select id={name} onChange={SelectionChange} value={value}  >
            {source.map((elem,index)=> <DropDownElement key={index} value={elem} />)}
        </select>
    );
};



export default DropDownFilter;