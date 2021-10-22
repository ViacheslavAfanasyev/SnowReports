import React, { useState, useEffect } from "react";
import StateCheckbox from "./StateCheckbox";

const url = '/api/data/States';



const TicketStates = ({Charts, SetCharts}) => {

    //const [ticketStates, setTicketStates] = useState([]);

    useEffect(()=> {
        async function populateStatesDropDown() {
            const response = await fetch(url);
            const data = await response.json();

            const resultArr = [];
            Object.keys(data).forEach(key => resultArr.push({name: key, label: data[key], checked: false}))
            resultArr[0].checked = true;
            resultArr[1].checked = true;

            SetCharts(resultArr);

        };

        populateStatesDropDown();
    },[]);

    return (
        <ul>
            {Charts.map(elem => <li><StateCheckbox CheckboxOnChange={(e)=>{let shallowArr = [...Charts]; shallowArr[elem.name].checked =  e.target.checked; SetCharts(shallowArr);             console.log(Charts)}} value={elem.name} label={elem.label} checked={elem.checked} /></li>)}
        </ul>
    );
};


export default TicketStates;