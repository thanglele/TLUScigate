// src/components/PrivateRoute.tsx
import { Navigate, Outlet } from "react-router-dom";

// Hàm kiểm tra trạng thái đăng nhập (dựa trên token trong localStorage)
const isAuthenticated = () => {
  const token = localStorage.getItem("token");
  return !!token; // Trả về true nếu có token, false nếu không có
};

const PrivateRoute = () => {
  return isAuthenticated() ? <Outlet /> : <Navigate to="/signin" replace />;
};

export default PrivateRoute;