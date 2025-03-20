// src/api/LectureApi.ts
import axios from "axios";

// Tạo instance của axios với baseURL và headers mặc định
const api = axios.create({
  baseURL: "https://scigateapi.thanglele08.id.vn/",
  headers: {
    "Content-Type": "application/json",
  },
});

// Hàm lấy danh sách tất cả Tạp chí ấn phẩm (GET /api/TapChiAnPham)
export const fetchTapChiAnPham = async () => {
  try {
    const response = await api.get("/api/TapChiAnPham");
    return response.data;
  } catch (error) {
    console.error("Error fetching TapChiAnPham data:", {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });
    const errorMessage = error.response?.data?.message || "Không thể tải dữ liệu Tạp chí ấn phẩm từ API";
    throw new Error(errorMessage);
  }
};

