import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import ReportPage from './components/Reports/ReportPage';

function App() {

    return (
        <BrowserRouter>
            <Routes>
                <Route path="start" element={<ReportPage/> }/>
            </Routes>
        </BrowserRouter>
    );
}

export default App;