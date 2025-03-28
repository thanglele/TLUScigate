import axios from "axios";

// Tạo instance của axios với baseURL và headers mặc định
const api = axios.create({
  baseURL: "http://api.thanglele.cloud",
  headers: {
    "Content-Type": "application/json",
  },
});

// Hàm lấy danh sách tất cả NCKH của giảng viên (GET /api/NCKHGiangVien)
export const fetchNCKHGiangVien = async () => {
  try {
      const token = localStorage.getItem("accessToken"); 
      const response = await api.get("/api/NCKHGiangVien", {
          headers: {
              Authorization: token,
          },
      });

      return response.data;
  } catch (error) {
      console.error("Error fetching NCKHGiangVien data:", {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
  });
  const errorMessage = error.response?.data?.message || "Không thể tải dữ liệu từ API";
  throw new Error(errorMessage);
}
};