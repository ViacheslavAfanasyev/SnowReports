import React from 'react';
import { ResponsiveContainer, AreaChart, XAxis, YAxis, Area, Tooltip, CartesianGrid } from 'recharts';
import {format, parseISO} from 'date-fns'
import styles from './TicketsNumberChart.module.css'

let IsColorInitialized = false;



let randomColor = () =>  "#"+Math.floor(Math.random()*16777215).toString(16);


const TicketsNumberChart = ({Source, Charts, SetCharts}) => {

    function InitializeChartColors()
    {

        if (!IsColorInitialized)
        {
            console.log("InitializeChartColors");

            const initializedChart = [];
            Charts.forEach(chart => initializedChart.push({...chart,color : randomColor()}));
            console.log(initializedChart);
            SetCharts(initializedChart);
            IsColorInitialized = true;
        }
    }

    return (
        <ResponsiveContainer width="100%" height={400}>
            <AreaChart data={Source} width="100%">
                <defs>
                    <linearGradient id="bluegradient" x1="0" y1="0" x2="0" y2="1" >
                        <stop offset="0%" stopColor="#2451B7" stopOpacity={0.4} />
                        <stop offset="75%" stopColor="#2451B7" stopOpacity={0.05} />
                    </linearGradient>
                    <linearGradient id="redgradient" x1="0" y1="0" x2="0" y2="1" >
                        <stop offset="0%" stopColor="red" stopOpacity={0.4} />
                        <stop offset="75%" stopColor="red" stopOpacity={0.05} />
                    </linearGradient>
                </defs>


                {Charts.map((chart) => {
                    InitializeChartColors(Charts);
                    return <Area dataKey={"value."+chart.label}  width="100%" type="monotone" stroke={chart.color} fill="url(#bluegradient)" strokeWidth="3px" hide={!chart.checked} />
                })}


                <XAxis dataKey="date" axisLine={false} tickLine={false} interval={Math.round(Source.length/10)}  tickFormatter={(dateTime)=>
                {
                    if (dateTime==0 || dateTime == 'auto')
                    {
                        return "";
                    }
                    console.log("DATETIME "+dateTime)
                    const date = parseISO(dateTime);
                    return format(date, "MMM dd");

                }} />
                <YAxis  axisLine={false} tickLine={false} tickCount={10}  />
                <Tooltip content={GetTooltip} />
                <CartesianGrid opacity={0.1} vertical={false} />
            </AreaChart>

        </ResponsiveContainer>
    );
};

function GetTooltip({active, payload, label})
{
if (active)
{
    if (label!='0' && payload!=null)
    {
        return <div className={styles.ToolTipLabel}>
            <h4 className={styles.ToolTipTitle}>{format(parseISO(label),"PPp")}</h4>
            {[payload.map(s=> <p className={styles.ToolTipChartInfo} style={{ color: s.color }} >{s.name.slice(6).replace('_',' ')} {s.value}</p>)]}


        </div>
    }

}
return "";
}

export default TicketsNumberChart;