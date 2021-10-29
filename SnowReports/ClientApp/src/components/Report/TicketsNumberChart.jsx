import React from 'react';
import { ResponsiveContainer, AreaChart, XAxis, YAxis, Area, Tooltip, CartesianGrid } from 'recharts';
import {format, parseISO} from 'date-fns'

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


                <XAxis dataKey="date" axisLine={false} tickLine={false} interval={300} tickFormatter={(dateTime)=>
                {
                    if (dateTime==0)
                    {
                        return "";
                    }
                    const date = parseISO(dateTime);
                    return format(date, "MMM dd");

                    const repeatedDate = Math.round(Source.length/15)
                    if (repeatedDate>30)
                    {
                        if (date.getDate()===1)
                        {
                            return format(date, "MMM, d");
                        }
                    }else if (date.getDate() % repeatedDate === 0) {
                        return format(date, "MMM, d");
                    }
                    return "";
                }} />
                <YAxis  axisLine={false} tickLine={false} tickCount={10}  />
                <Tooltip />
                <CartesianGrid opacity={0.1} vertical={false} />
            </AreaChart>

        </ResponsiveContainer>
    );
};

export default TicketsNumberChart;