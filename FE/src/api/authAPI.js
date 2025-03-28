// src/api/authAPI.ts
import axios from 'axios';

const API_URL = 'http://api.thanglele.cloud';
//const API_URL = 'http://localhost:5186';

const api = axios.create({
  baseURL: API_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

export const login = async (credentials) => {
  try {
    const response = await api.post('/Auth/Login', {
      email: credentials.email,
      password: credentials.password,
    });

    const { accessToken } = response.data;
    
    if (accessToken) {
      // Lưu token vào localStorage (hoặc sessionStorage nếu muốn chỉ lưu tạm thời)
      localStorage.setItem("accessToken", accessToken);
      localStorage.setItem("role", response.data.role);
    }

    console.log("Đăng nhập thành công:", response.data);
    return response.data;
  } catch (error) {
    console.error('Login Error:', {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });
    const errorMessage = error.response?.data?.messages || 'Đăng nhập thất bại';
    throw new Error(errorMessage);
  }
};

export const forgotPassword = async (credentials) => {
  try {
    const response = await api.post('/Auth/forgetpassword', {
      email: credentials.email,
      password: "null",
    });
    return response.data;
  } catch (error) {
    console.error('Forgot Password Error:', {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });
    const errorMessage = error.response?.data?.messages || 'Không thể gửi yêu cầu quên mật khẩu';
    throw new Error(errorMessage);
  }
};

export const checkOTP = async (otpData) => {
  try {
    const response = await api.post('/Auth/CheckOTP', {
      email: otpData.email,
      otp: otpData.otp,
    });
    return response.data;
  } catch (error) {
    console.error('Check OTP Error:', {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });
    const errorMessage = error.response?.data?.messages || 'Mã OTP không hợp lệ';
    throw new Error(errorMessage);
  }
};

export const newPassword = async (data) => {
  try {
    const response = await api.post('/Auth/NewPassword', {
      email: data.email,
      password: data.password,
    });
    return response.data;
  } catch (error) {
    console.error('New Password Error:', {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });
    const errorMessage = error.response?.data?.messages || 'Không thể đặt lại mật khẩu';
    throw new Error(errorMessage);
  }
};

export const logout = () => {
  try {
    localStorage.removeItem("accessToken");
    return true;
  } catch (error) {
    console.error('Logout Error:', error.message);
    return false;
  }
}