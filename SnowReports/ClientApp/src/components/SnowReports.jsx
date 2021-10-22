import React, {useState, useEffect } from 'react';
import { ResponsiveContainer, AreaChart, XAxis, YAxis, Area, Tooltip, CartesianGrid } from 'recharts';
import {format, parseISO} from 'date-fns'
import TicketStates from "./TicketState/TicketStates";

const url = '/api/snowreports/GetRangedDate?startDate=2021-05-08&endDate=2021-09-29&state=3';
let loadedNoResults = "No Results"
let IsColorInitialized = false;

const SnowReports = () => {

    const [dataArr, setDataArr] = useState([]);
    const [loaded, setLoaded] = useState(false);
    const [charts, setCharts] = useState([]);

    async function ExportData()
    {
        const response = await fetch(url).then((r)=>{
            if (r.ok)
            {
                //console.log("r - "+r);

            }
            else
            {
                loadedNoResults = "ERROR";
                //console.log("ERROR loading from - "+url);
            }
            return r;
        })

        if (response.ok)
        {
            setDataArr(await response.json());
        }

        setLoaded(true);
    }

    function InitializeChartColors()
    {

        if (!IsColorInitialized)
        {
            console.log("InitializeChartColors");

            const initializedChart = [];
            charts.forEach(chart => initializedChart.push({...chart,color : randomColor()}));
            console.log(initializedChart);
            setCharts(initializedChart);
            IsColorInitialized = true;
        }
    }

    useEffect(()=>{
        ExportData();
        }, [])

    return(
    <div>
        <TicketStates Charts={charts} SetCharts={setCharts}/>
        <ResponsiveContainer width="100%" height={400}>
            <AreaChart data={dataArr} width="100%">
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


                {charts.map((chart) => {
                    InitializeChartColors();
                    console.log(chart.color)
                    return <Area dataKey={"value."+chart.label}  width="100%" type="monotone" stroke={chart.color} fill="url(#bluegradient)" strokeWidth="3px" hide={!chart.checked} />
                })}


                <XAxis dataKey="date" axisLine={false} tickLine={false} interval={0} tickFormatter={(dateTime)=>
                {
                    const date = parseISO(dateTime);
                    const repeatedDate = Math.round(dataArr.length/15)

                    if (repeatedDate>30)
                    {
                        if (date.getDate()===1)
                        {
                            return format(date, "MMM, d");;
                        }
                    }else if (date.getDate() % repeatedDate === 0) {
                        return format(date, "MMM, d");;
                    }
                    return "";
                  }} />
                <YAxis  axisLine={false} tickLine={false} tickCount={10}  />
                <Tooltip />
                <CartesianGrid opacity={0.1} vertical={false} />
            </AreaChart>

        </ResponsiveContainer>
    </div>
    );
};



let randomColor = () =>  "#"+Math.floor(Math.random()*16777215).toString(16);

export default SnowReports;