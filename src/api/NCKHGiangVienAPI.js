// src/api/NCKHGiangVienAPI.js
import axios from "axios";

// Tạo instance của axios với baseURL và headers mặc định
const api = axios.create({
  baseURL: "https://scigateapi.thanglele08.id.vn/",
  headers: {
    "Content-Type": "application/json",
  },
});

// Hàm lấy danh sách tất cả NCKH của giảng viên (GET /api/NCKHGiangVien)
export const fetchNCKHGiangVien = async () => {
  try {
    const response = await api.get("/api/NCKHGiangVien");
    return response.data;
  } catch (error: any) {
    console.error("Error fetching NCKHGiangVien data:", {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });
    const errorMessage =
      error.response?.data?.message ||
      "Không thể tải dữ liệu NCKH giảng viên từ API";
    throw new Error(errorMessage);
  }
};