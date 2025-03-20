// src/api/LectureApi.ts
import axios from "axios";

const api = axios.create({
  baseURL: "https://scigateapi.thanglele08.id.vn/",
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
  
      return response.data;
    } catch (error) {
      console.error("Error fetching lecture data:", {
        message: error.message,
        response: error.response?.data,
        status: error.response?.status,
      });
      const errorMessage = error.response?.data?.message || "Không thể tải dữ liệu từ API";
      throw new Error(errorMessage);
    }
  };
  

export const createLecture = async (lectureData) => {
  try {
    const response = await api.post("/api/GiangVien", lectureData);
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

    const errorMessage = error.response?.data?.title || "Thêm bài giảng thất bại";
    throw new Error(errorMessage);
  }
};

export const updateLecture = async (lectureId, lectureData) => {
  try {
    const response = await api.put(`/api/GiangVien/${lectureId}`, lectureData);
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

    const errorMessage = error.response?.data?.title || "Cập nhật bài giảng thất bại";
    throw new Error(errorMessage);
  }
}

export const deleteLecture = async (lectureId) => {
  try {
    const response = await api.delete(`/api/GiangVien/${lectureId}`);
    return response.data;
  } catch (error) {
    console.error("Error deleting lecture data:", {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });

    const errorMessage = error.response?.data?.title || "Xóa bài giảng thất bại";
    throw new Error(errorMessage);
  }
}