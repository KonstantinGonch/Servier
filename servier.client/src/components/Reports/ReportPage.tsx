import { useEffect, useState } from 'react';

interface SalesItem {
    finYear: number;
    product: string;
    valueCount: number;
    shop: string;
}

function ReportPage() {
    const [items, setItems] = useState<SalesItem[]>();

    useEffect(() => {
        populateReportData();
    }, []);

    return (
        <div>
            <h1 id="tableLabel">Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {items?.map(item => <p>{item.finYear}</p>)}
        </div>
    );

    async function populateReportData() {
        const response = await fetch('http://localhost:5150/api/reports/getReport');
        const data = await response.json();
        setItems(data);
    }
}

export default ReportPage;