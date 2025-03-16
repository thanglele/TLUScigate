import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import './index.css';
import LoginPage from './assets/Page/LoginPage';

import ForgotPassword from './assets/Page/ForgotPasswordPage';
import OTPPage from './assets/Page/OTPPage';
import DashBoardPage from './assets/Page/DashBoardPage';


function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<LoginPage />} />
        <Route path="/dashboard" element={<DashBoardPage />} />
        <Route path="/forgot-password" element={<ForgotPassword />} />
        <Route path="/otp" element={<OTPPage />} />
      </Routes>
    </Router>
  );
}

export default App;