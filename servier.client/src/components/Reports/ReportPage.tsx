import { useEffect, useState } from 'react';
import SalesIncreaseReportItem from '../../models/SalesIncreaseReportItem';
import SalesIncreaseChart from '../Charts/SalesIncreaseChart';
import YearlyIncreaseChart from '../Charts/YearlyIncreaseChart';
import ReportItemIncreaseByYears from '../../models/ReportItemIncreaseByYears';

interface SalesItem {
    finYear: number;
    product: string;
    valueCount: number;
    shop: string;
}

enum DivisionType {
    byItem = 1,
    byShop
}

function ReportPage() {
    const [items, setItems] = useState<SalesItem[]>();
    const [salesIncreaseItems, setSalesIncreaseItems] = useState<SalesIncreaseReportItem[]>();
    const [yearlyIncreaseItems, setYearlyIncreaseItems] = useState<ReportItemIncreaseByYears[]>();

    useEffect(() => {
        populateReportData();
        getSalesIncreaseReport(DivisionType.byItem);
        getYearlyIncreaseReport('','');
    }, []);

    return (
        <div>
            <h1 id="tableLabel">Weather forecast</h1>
            <p>Прирост продаж</p>
            <SalesIncreaseChart items={salesIncreaseItems} />
            <p>График продаж</p>
            <YearlyIncreaseChart items={yearlyIncreaseItems}/>
        </div>
    );

    async function populateReportData() {
        const response = await fetch('http://localhost:5150/api/reports/getReport');
        const data = await response.json();
        console.log(items);
        setItems(data);
    }

    async function getSalesIncreaseReport(divType: DivisionType) {
        const response = await fetch('http://localhost:5150/api/reports/getSalesIncrease?divisionType=' + divType);
        const data = await response.json();
        setSalesIncreaseItems(data);
    }

    async function getYearlyIncreaseReport(byItem: string, byShop: string) {
        const response = await fetch('http://localhost:5150/api/reports/getYearlyIncrease?byItem=' + byItem + '&byShop=' + byShop);
        const data = await response.json();
        setYearlyIncreaseItems(data);
    }
}

export default ReportPage;