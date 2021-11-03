import React, {useState, useEffect} from 'react';
import AssignmentGroup from "./AssignmentGroup";

const url = process.env.REACT_APP_SNOW_HOST+'/api/data/AssignmentGroups';
const AssignmentGroupsDropDown = ({SetAssignmentGroup}) => {

    const [assigementGroups,setAssigementGroups] = useState([]);
    const [selectedValue,setselectedValue] = useState(0);


    useEffect(async()=> {
            const response = await fetch(url);
            const data = await response.json();
            Object.keys(data).forEach(key => assigementGroups.push({value: key, name: data[key]}))

    },[]);

    function SelectionChange(e)
    {
        SetAssignmentGroup(e.target.value);
        setselectedValue(e.target.value);
    }


    return (
        <select id="AssignmentGroups" onChange={SelectionChange} value={selectedValue}  >
            {assigementGroups.map(v=> <AssignmentGroup value={v.value} name={v.name} />)}
        </select>
    );
};



export default AssignmentGroupsDropDown;