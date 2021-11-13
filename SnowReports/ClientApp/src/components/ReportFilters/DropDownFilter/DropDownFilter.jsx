import React, {useState, useEffect} from 'react';
import DropDownElement from "./DropDownElement";


const DropDownFilter = ({setSelectedValue, source, name}) => {

    const storageKey = name+"_dropDownFilter";
    const [value, setValue] = useState();

    let storageValue = localStorage.getItem(storageKey);

    useEffect(()=>{
        if (storageValue!=undefined)
        {
            setSelectedValue(storageValue);
            setValue(storageValue);
        }
        else
        if (source!=undefined && source[0]!=undefined)
        {
            const val = source[0].value!=undefined?source[0].value:source[0];
            setSelectedValue(val);
            setValue(val);
        }

    },[source])

    function SelectionChange(e)
    {
        setSelectedValue(e.target.value);
        setValue(e.target.value);
        localStorage.setItem(storageKey, e.target.value);
    }

    if (source==null || source == undefined)
    {
        console.log("DropDownFilter component | source variable is null or undefined | "+name);
        return <div></div>
    }

    if (!Array.isArray(source))
    {
        console.log("DropDownFilter component | source is not an array | "+name + " "+source);
        return  <div></div>
    }

    return (
        <select id={name} onChange={SelectionChange} value={value}  >
            {source.map((elem,index)=> <DropDownElement key={index} value={elem} />)}
        </select>
    );
};



export default DropDownFilter;