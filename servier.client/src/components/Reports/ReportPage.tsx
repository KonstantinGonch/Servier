/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable @typescript-eslint/no-require-imports */
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

    const [itemFilter, setItemFilter] = useState<string>('');
    const [shopFilter, setShopFilter] = useState<string>('');
    const [divisionFilter, setDivisionFilter] = useState<DivisionType>(DivisionType.byItem);

    const [shopItems, setShopItems] = useState<string[]>([]);
    const [shops, setShops] = useState<string[]>([]);

    useEffect(() => {
        populateReportData();
        getSalesIncreaseReport(DivisionType.byItem);
        getYearlyIncreaseReport('', '');
        getShopItems();
        getShops();
    }, []);

    return (
        <div>
            <h1 id="tableLabel">Отчеты о продажах</h1>
            <p>Прирост продаж</p>
            <SalesIncreaseChart items={salesIncreaseItems} />
            <p>График продаж</p>
            <YearlyIncreaseChart items={yearlyIncreaseItems} />
            <button onClick={createCsvForSalesReport}>Экспортировать в CSV</button>
        </div>
    );

    function createCsvForSalesReport() {
        const json2csv = require('json2csv');
        const fs = require('fs');

        json2csv({ data: salesIncreaseItems, fields: ['previousValue', 'currentValue', 'percentage', 'name'] }, function (err: any, csv: any) {
            if (err) console.log(err);
            fs.writeFile('data.csv', csv, function (err: any) {
                if (err) throw err;
                console.log('cars file saved');
            });
        });
    }

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

    async function getShopItems() {
        const response = await fetch('http://localhost:5150/api/shopItems/items');
        const data = await response.json();
        setShopItems(data);
    }

    async function getShops() {
        const response = await fetch('http://localhost:5150/api/shops/items');
        const data = await response.json();
        setShops(data);
    }
}

export default ReportPage;
