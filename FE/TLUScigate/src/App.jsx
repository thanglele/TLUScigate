import {
  BrowserRouter as Router,
  Routes,
  Route,
} from "react-router-dom";
import FormLogin from "./assets/LoginPage/FormLogin";
import Dashboard from "./assets/DashBoard/Admin";
import Welcome from "./assets/LoginPage/Welcome";
import "./index.css";

function App() {
  return (
    <Router>
      <Routes>
        <Route
          path="/"
          element={
            <div className="min-h-screen custom-gradient flex justify-center items-center">
              <div className="flex flex-col md:flex-row justify-between w-full max-w-6xl px-5 gap-5 md:gap-60 m-2">
                <Welcome />
                <FormLogin />
              </div>
            </div>
          }
        />
        <Route path="/dashboard" element={<Dashboard />} />
      </Routes>
    </Router>
  );
}

export default App;
