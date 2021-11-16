import React, {useContext} from 'react';
import { ResponsiveContainer, AreaChart, XAxis, YAxis, Area, Tooltip, CartesianGrid } from 'recharts';
import {format, parseISO} from 'date-fns'
import styles from './TicketsNumberChart.module.css'
import {ReportFiltersContext} from "../../context/ReportFiltersContext";

const colorList = [  'Plum', 'YellowGreen','Gold', 'DeepPink', 'PowderBlue',  'Violet', 'PapayaWhip']

const TicketsNumberChart = () => {

    const {chartData, chartLines, displayCombinedGraph}= useContext(ReportFiltersContext)

    let combinedGraph = [];

    if (displayCombinedGraph)
    {
        const checkedGraphs = chartLines.filter(v=>v.checked);

        chartData.map((element, index)=>{

            let sum = 0;
            checkedGraphs.map((e,i)=>{

                sum += element.value[e.value];
            })

            combinedGraph.push({date: element.date, value_Combined:sum})


        });


        console.log("Checked Graphs -"+checkedGraphs);
    }

    return (
        <div id={styles.ReportBlock}>
        <ResponsiveContainer width="100%" height={400}>
            <AreaChart data={displayCombinedGraph?combinedGraph:chartData} width="100%">
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


                if (displayCombinedGraph)
                {
                     <Area dataKey={"value_Combined"} width="100%" type="monotone"
                                     stroke={colorList[0]} fill="url(#bluegradient)"
                                     strokeWidth="3px" />
                }
                else
                {

                        chartLines.map((line, index) => {
                            return <Area key={index} dataKey={"value." + line.value} width="100%" type="monotone"
                                         stroke={colorList[(index % colorList.length)]} fill="url(#bluegradient)"
                                         strokeWidth="3px" hide={!line.checked}/>
                        })

                }

                <XAxis dataKey="date" axisLine={false} tickLine={false} interval={Math.round(chartData.length/10)}  tickFormatter={(dateTime)=>
                {
                    if (dateTime==0 || dateTime == 'auto')
                    {
                        return "";
                    }

                    const date = parseISO(dateTime);
                    return format(date, "MMM dd");

                }} />
                <YAxis  axisLine={false} tickLine={false} tickCount={10}  />
                <Tooltip content={GetTooltip} />
                <CartesianGrid opacity={0.1} vertical={false} />
            </AreaChart>

        </ResponsiveContainer>
        </div>
    );
};

function GetTooltip({active, payload, label})
{
if (active)
{
    if (label!='0' && payload!=null)
    {
        return <div className={styles.ToolTipLabel}>
            <h4 className={styles.ToolTipTitle}>{format(parseISO(label),"ccc, d MMM, k:mm a")}</h4>
            {[payload.map((s, index)=> <p key={index} className={styles.ToolTipChartInfo} style={{ color: s.color }} >{s.name.slice(6).replace('_',' ')} {s.value}</p>)]}
        </div>
    }
}
return "";
}

export default TicketsNumberChart;