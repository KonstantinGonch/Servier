import { ResponsiveContainer, BarChart, CartesianGrid, XAxis, YAxis, Tooltip, Legend, Bar, Rectangle } from "recharts";
import ReportItemIncreaseByYears from "../../models/ReportItemIncreaseByYears";

type Props = {
    items: ReportItemIncreaseByYears[] | undefined;
}
function YearlyIncreaseChart({ items }: Props) {

    const data = items?.map(el => {
        return {
            uv: el.percentage,
            pv: el.salesSum,
            name: el.year
        }
    });


    return (
        <ResponsiveContainer width="100%" height="100%">
            <BarChart
                width={500}
                height={300}
                data={data}
                margin={{
                    top: 5,
                    right: 30,
                    left: 20,
                    bottom: 5,
                }}
            >
                <CartesianGrid strokeDasharray="3 3" />
                <XAxis dataKey="name" />
                <YAxis />
                <Tooltip />
                <Legend />
                <Bar dataKey="pv" fill="#8884d8" activeBar={<Rectangle fill="pink" stroke="blue" />} />
                <Bar dataKey="uv" fill="#82ca9d" activeBar={<Rectangle fill="gold" stroke="purple" />} />
            </BarChart>
        </ResponsiveContainer>
    );
}

export default YearlyIncreaseChart;