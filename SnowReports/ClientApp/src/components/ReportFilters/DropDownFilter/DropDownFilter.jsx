import React, {useState, useEffect} from 'react';
import DropDownElement from "./DropDownElement";


const DropDownFilter = ({setSelectedValue, source, name}) => {

    const [selectedValue, setselectedValue] = useState(source[0]);

    function SelectionChange(e)
    {
        setSelectedValue(e.target.value);
        setselectedValue(e.target.value);
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

    console.log(source.length)

    return (
        <select id={name} onChange={SelectionChange} value={selectedValue}  >
            {source.map(v=> <DropDownElement value={v} />)}
        </select>
    );
};



export default DropDownFilter;