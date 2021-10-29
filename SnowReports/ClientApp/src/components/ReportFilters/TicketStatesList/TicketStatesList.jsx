import React, { useState, useEffect } from "react";
import TicketStateCheckbox from "./TicketStateCheckbox";
import styles from './TicketStatesList.module.css'
const url = '/api/data/States';



const TicketStatesList = ({Charts, SetCharts}) => {

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
        <ul className={styles.TicketStatesList} >
            {Charts.map(elem => <li><TicketStateCheckbox CheckboxOnChange={(e)=>{let shallowArr = [...Charts]; shallowArr[elem.name].checked =  e.target.checked; SetCharts(shallowArr);             console.log(Charts)}} value={elem.name} label={elem.label} checked={elem.checked} /></li>)}
        </ul>
    );
};


export default TicketStatesList;