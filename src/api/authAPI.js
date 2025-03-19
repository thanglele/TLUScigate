import axios from 'axios';

const API_URL = 'https://scigateapi.thanglele08.id.vn';

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
    const errorMessage = error.response?.data?.messages;
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
    throw new Error(error.response?.data?.message);
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
    throw new Error(error.response?.data?.message);
  }
};