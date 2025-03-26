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
      const token = localStorage.getItem("accessToken"); 
      const response = await api.get("/api/TapChiAnPham", {
          headers: {
              Authorization: token,
          },
      });

      return response.data;
  } catch (error) {
      console.error("Error fetching NCKHTapChiAnPham data:", {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
  });
  const errorMessage = error.response?.data?.message || "Không thể tải dữ liệu từ API";
  throw new Error(errorMessage);
}
};

export const deleteTapChiAnPham = async (id) => {
  try {
     const token = localStorage.getItem("accessToken"); 
      const response = await api.delete("/api/TapChiAnPham", {
          headers: {
              Authorization: token,
          },
      });
  } catch (error) {
    console.error("Error deleting NCKHTapChiAnPham data:", {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });
    const errorMessage = error.response?.data?.message || "Xóa tạp chí ấn phẩm thất bại";
    throw new Error(errorMessage);
  }
}