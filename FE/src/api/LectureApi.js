// src/api/LectureApi.ts
import axios from "axios";

//const BASE_URL = "http://localhost:5186";
const BASE_URL = "http://api.thanglele.cloud";

const api = axios.create({
  baseURL: BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

export const fetchLectureData = async () => {
  try {
    // Lấy accessToken từ localStorage
    const token = localStorage.getItem("accessToken");

    const response = await api.get("/api/GiangVien", {
      headers: {
        Authorization: token, // Thêm token vào header
      },
    });

    return response;
  } catch (error) {
    console.error("Error fetching lecture data:", {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });
    const errorMessage =
      error.response?.data?.message || "Không thể tải dữ liệu từ API";
    throw new Error(errorMessage);
  }
};

export const createLecture = async (lectureData) => {
  try {
    const token = localStorage.getItem("accessToken");
    const response = await api.post(`/api/GiangVien`, lectureData, {
      headers: {
        Authorization: token, // Gửi token trong header
      },
    });
    return response.data;
  } catch (error) {
    console.error("Error creating lecture data:", {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });

    // Lấy chi tiết lỗi từ 'errors' nếu có
    if (error.response?.data?.errors) {
      const errorMessages = Object.entries(error.response.data.errors)
        .map(([field, messages]) => `${field}: ${messages.join(", ")}`)
        .join("; ");
      throw new Error(`Validation failed: ${errorMessages}`);
    }

    const errorMessage =
      error.response?.data?.title || "Thêm giảng viên thất bại";
    throw new Error(errorMessage);
  }
};

export const updateLecture = async (lectureId, lectureData) => {
  try {
    const token = localStorage.getItem("accessToken");
    const response = await api.put(`/api/GiangVien/${lectureId}`, lectureData, {
      headers: {
        Authorization: token, // Gửi token trong header
      },
    });
    return response.data;
  } catch (error) {
    console.error("Error updating lecture data:", {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });

    // Lấy chi tiết lỗi từ 'errors' nếu có
    if (error.response?.data?.errors) {
      const errorMessages = Object.entries(error.response.data.errors)
        .map(([field, messages]) => `${field}: ${messages.join(", ")}`)
        .join("; ");
      throw new Error(`Validation failed: ${errorMessages}`);
    }

    const errorMessage =
      error.response?.data?.title || "Cập nhật giảng viên thất bại";
    throw new Error(errorMessage);
  }
};

export const deleteLecture = async (lectureId) => {
  try {
    const token = localStorage.getItem("accessToken");

    const response = await api.delete(`/api/GiangVien/${lectureId}`, {
      headers: {
        Authorization: token,
      },
    });

    return response.data;
  } catch (error) {
    console.error("Error deleting lecture data:", {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });

    const errorMessage =
      error.response?.data?.title || "Xóa giang vien thất bại";
    throw new Error(errorMessage);
  }
};

export const viewDetail = async (lectureId) => {
  try {
    // Lấy accessToken từ localStorage
    const token = localStorage.getItem("accessToken");

    const response = await fetch(BASE_URL + `/api/GiangVien/${lectureId}`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: token,
      },
    });

    return await response.json();
  } catch (error) {
    console.error("Error fetching lecture data:", {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });
    const errorMessage =
      error.response?.data?.message || "Không thể tải dữ liệu từ API";
    throw new Error(errorMessage);
  }
};
