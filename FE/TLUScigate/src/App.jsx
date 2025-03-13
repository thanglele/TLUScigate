import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import LoginPage from '/Users/leduc/QLKHTLU/src/assets/components/pages/LoginPage.jsx';
import Dashboard from '/Users/leduc/QLKHTLU/src/assets/components/pages/Dashboard.jsx'; // Cập nhật đường dẫn
import './index.css';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<LoginPage />} />
        <Route path='/pages/' element={Dashboard}></Route>
      </Routes>
    </Router>
  );
}

export default App;