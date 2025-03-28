import axios from "axios";

const api = axios.create ({
    baseURL: "https://scigateapi.thanglele08.id.vn/",
    headers: {
        "Content-Type": "application/json",
    },
});

export const fetchNCKHSinhVien = async () => {
    try {
        const token = localStorage.getItem("accessToken"); 
        const response = await api.get("/api/NCKHSinhVien", {
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