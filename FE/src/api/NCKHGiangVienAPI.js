import axios from "axios";

//const BASE_URL = "http://localhost:5186/";
const BASE_URL = "http://api.thanglele.cloud";

// Tạo instance của axios với baseURL và headers mặc định
const api = axios.create({
  baseURL: BASE_URL,
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

    return response;
  } catch (error) {
    console.error("Error fetching NCKHGiangVien data:", {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
    });
    const errorMessage =
      error.response?.data?.message || "Không thể tải dữ liệu từ API";
    throw new Error(errorMessage);
  }
};

export const createNCKHGiangVien = async (NCKHGiangVienData) => {
  try {
    const token = localStorage.getItem("accessToken");
    const response = await api.post(`/api/NCKHGiangVien`, NCKHGiangVienData, {
      headers: {
        Authorization: token, // Gửi token trong header
      },
    });
    return response.data;
  } catch (error) {
    console.error("Error creating NCKHGiangVien data:", {
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
      error.response?.data?.title || "Thêm nghiên cứu khoa học giảng viên thất bại";
    throw new Error(errorMessage);
  }
};

export const fetchNCKHGiangVienbyID = async (id) => {
  try {
    const token = localStorage.getItem("accessToken");
    const response = await api.get(`/api/NCKHGiangVien/${Number(id)}`, {
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
    const errorMessage =
      error.response?.data?.message || "Không thể tải dữ liệu từ API";
    throw new Error(errorMessage);
  }
};

export const RemoveNCKHGiangVienbyID = async (id) => {
  try {
    const token = localStorage.getItem("accessToken");
    const response = await api.delete(`/api/NCKHGiangVien/${Number(id)}`, {
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
    const errorMessage =
      error.response?.data?.message || "Không thể tải dữ liệu từ API";
    throw new Error(errorMessage);
  }
};

export const UpdateNCKHGiangVienbyID = async (id, NCKHGiangVienData) => {
  try {
    const token = localStorage.getItem("accessToken");
    const response = await api.put(`/api/NCKHGiangVien/${Number(id)}`, NCKHGiangVienData,{
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
    const errorMessage =
      error.response?.data?.message || "Không thể tải dữ liệu từ API";
    throw new Error(errorMessage);
  }
};