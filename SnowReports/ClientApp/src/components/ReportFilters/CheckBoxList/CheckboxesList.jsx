import React, { useState, useEffect } from "react";
import Checkbox from "./Checkbox";
import styles from './CheckboxesList.module.css'
/*
const url = process.env.REACT_APP_SNOW_HOST+'/api/SnowReports/States';
*/



//const CheckboxesList = ({Charts, SetCharts}) => {
const CheckboxesList = ({setSelectedValue, source, name}) => {

/*
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
*/
    if (source==null || source == undefined)
    {
        console.log("CheckboxesList component | source variable is null or undefined");
        return <div></div>
    }

    if (!Array.isArray(source))
    {
        console.log("CheckboxesList component | source is not an array");
        return  <div></div>
    }

        return (
        <ul id={name} className={styles.TicketStatesList} >
            {source.map((elem, index) => <li key={index}><Checkbox CheckboxOnChange={(e)=>{let shallowArr = [...source]; shallowArr[elem.key].checked = e.target.checked;
            setSelectedValue(shallowArr);
            console.log(shallowArr);
          }} key={elem.key} value={elem.value} label={elem.value} checked={elem.checked} /></li>)}
        </ul>
    );

/*    return (
        <ul className={styles.CheckBoxList} >
            {Charts.map(elem => <li><Checkbox CheckboxOnChange={(e)=>{let shallowArr = [...Charts]; shallowArr[elem.name].checked =  e.target.checked; SetCharts(shallowArr);             console.log(Charts)}} value={elem.name} label={elem.label} checked={elem.checked} /></li>)}
        </ul>
    );*/
};


export default CheckboxesList;