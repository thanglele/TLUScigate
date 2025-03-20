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

// Hàm tạo mới một Tạp chí ấn phẩm (POST /api/TapChiAnPham)
export const createTapChiAnPham = async (data) => {
  try {
    const response = await api.post("/api/TapChiAnPham", data);
    return response.data;
  } catch (error) {
    console.error("Error creating TapChiAnPham:", {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });
    const errorMessage = error.response?.data?.message || "Không thể tạo mới Tạp chí ấn phẩm";
    throw new Error(errorMessage);
  }
};

// Hàm lấy thông tin chi tiết một Tạp chí ấn phẩm theo ID (GET /api/TapChiAnPham/{id})
export const fetchTapChiAnPhamById = async (id) => {
  try {
    const response = await api.get(`/api/TapChiAnPham/${id}`);
    return response.data;
  } catch (error) {
    console.error("Error fetching TapChiAnPham by ID:", {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });
    const errorMessage = error.response?.data?.message || "Không thể tải dữ liệu Tạp chí ấn phẩm theo ID";
    throw new Error(errorMessage);
  }
};

// Hàm cập nhật một Tạp chí ấn phẩm theo ID (PUT /api/TapChiAnPham/{id})
export const updateTapChiAnPham = async (id, data) => {
  try {
    const response = await api.put(`/api/TapChiAnPham/${id}`, data);
    return response.data;
  } catch (error) {
    console.error("Error updating TapChiAnPham:", {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });
    const errorMessage = error.response?.data?.message || "Không thể cập nhật Tạp chí ấn phẩm";
    throw new Error(errorMessage);
  }
};

// Hàm xóa một Tạp chí ấn phẩm theo ID (DELETE /api/TapChiAnPham/{id})
export const deleteTapChiAnPham = async (id) => {
  try {
    const response = await api.delete(`/api/TapChiAnPham/${id}`);
    return response.data;
  } catch (error) {
    console.error("Error deleting TapChiAnPham:", {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });
    const errorMessage = error.response?.data?.message || "Không thể xóa Tạp chí ấn phẩm";
    throw new Error(errorMessage);
  }
};