import axios from "axios";

const api = axios.create({
  baseURL: "http://api.thanglele.cloud",
  headers: {
    "Content-Type": "application/json",
  },
});

export const fetchScienceData = async () => {
    try {
      //lay accessToken tu localStorage
      const token = localStorage.getItem("accessToken");

      const response = await api.get("api/CongBoKhoaHoc",{
        headers: {
          Authorization: token,
        },
      });

      return response.data;
    } catch (error) {
      console.error("Error fetching sience data:", {
        message: error.message,
        response: error.response?.data,
        status: error.response?.status,
      });
      const errorMessage = error.response?.data?.message || "Không thể tải dữ liệu từ API";
      throw new Error(errorMessage);
    }
}

export const createScience = async (scienceData) => {
  try {
    const response = await api.post("api/CongBoKhoaHoc", scienceData);
    return response.data;
  } catch (error) {
    console.error("Error creating science data:", {
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

    const errorMessage = error.response?.data?.title || "Thêm công bố khoa học thất bại";
    throw new Error(errorMessage);
  }
};