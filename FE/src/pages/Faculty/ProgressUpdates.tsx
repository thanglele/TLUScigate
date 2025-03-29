import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
// @ts-ignore
import { fetchNCKHGiangVienbyID, UpdateNCKHGiangVienbyID, } from "../../api/NCKHGiangVienAPI";
// @ts-ignore
import { NCKHGiangVien } from "../../types/NCKHGiangVien"; // Import interface nếu cần

export default function ProgressUpdates() {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  const [facultyData, setFacultyData] = useState<NCKHGiangVien | null>(null);
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadFacultyData = async () => {
      try {
        const response = await fetchNCKHGiangVienbyID(Number(id));
        console.log("Fetched Data:", response);
        setFacultyData(response);
      } catch (error) {
        const err = error as Error;
        setError(
          err.message || "Không thể tải dữ liệu từ API. Vui lòng thử lại sau!"
        );
        console.error("Fetch error:", error);
      } finally {
        setLoading(false);
      }
    };

    loadFacultyData();
  }, [id]);

  const handleUpdate = async () => {
    if (facultyData) {
      try {
        await UpdateNCKHGiangVienbyID(facultyData.id, facultyData);
        navigate("/giang-vien-nghien-cuu"); // Chuyển hướng sau khi cập nhật thành công
      } catch (error) {
        console.error("Error updating faculty data:", error);
      }
    }
  };

  if (loading) return <div>Loading...</div>;
  if (error) return <div>{error}</div>;

  const RequiredLabel = ({ children }: { children: string }) => (
    <span className="text-sm font-medium text-gray-700 dark:text-gray-200">
      {children} <span className="text-red-500">*</span>
    </span>
  );

  return (
    <div className="p-6 bg-white rounded-lg shadow-sm dark:bg-gray-800">
      <h1 className="text-2xl text-center font-bold mb-6 text-gray-800 dark:text-white">
        ĐỀ TÀI - {facultyData?.tenDeTai}
      </h1>
      <div className="pb-4">
        <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
          1. Thông tin chung
        </span>
        <div className="grid pb-5 grid-cols-1 md:grid-cols-3 gap-4">
          <div>
            <RequiredLabel>Tên đề tài</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.tenDeTai}
              onChange={(e) =>
                setFacultyData({ ...facultyData, tenDeTai: e.target.value })
              }
            />
          </div>
          <div>
            <RequiredLabel>Mã đề tài</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.maDeTai}
              onChange={(e) =>
                setFacultyData({ ...facultyData, maDeTai: e.target.value })
              }
            />
          </div>
          <div>
            <RequiredLabel>Lĩnh vực nghiên cứu</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.linhVucNghienCuu.join(", ")}
              onChange={(e) =>
                setFacultyData({
                  ...facultyData,
                  linhVucNghienCuu: e.target.value.split(", "),
                })
              }
            />
          </div>
        </div>
        <div className="grid pb-5 grid-cols-1 md:grid-cols-3 gap-4">
          <div>
            <RequiredLabel>Chủ nhiệm đề tài</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.chuNhiemDeTai}
              onChange={(e) =>
                setFacultyData({
                  ...facultyData,
                  chuNhiemDeTai: e.target.value,
                })
              }
            />
          </div>
          <div>
            <RequiredLabel>Ngành</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.nganh}
              onChange={(e) =>
                setFacultyData({ ...facultyData, nganh: e.target.value })
              }
            />
          </div>
          <div>
            <RequiredLabel>Khoa</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.khoa}
              onChange={(e) =>
                setFacultyData({ ...facultyData, khoa: e.target.value })
              }
            />
          </div>
        </div>
      </div>
      {/* Thời gian thực hiện */}
      <div className="pb-4">
        <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
          2. Thời gian thực hiện
        </span>
        <div className="grid pb-5 grid-cols-1 md:grid-cols-2 gap-4 pt-2">
          <div>
            <RequiredLabel>Ngày bắt đầu</RequiredLabel>
            <input
              type="date"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.ngayBatDau}
              onChange={(e) =>
                setFacultyData({ ...facultyData, ngayBatDau: e.target.value })
              }
            />
          </div>
          <div>
            <RequiredLabel>Ngày kết thúc dự kiến</RequiredLabel>
            <input
              type="date"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.ngayKetThuc}
              onChange={(e) =>
                setFacultyData({ ...facultyData, ngayKetThuc: e.target.value })
              }
            />
          </div>
        </div>
      </div>
      {/* Kinh phí và tài trợ */}
      <div className="pb-4">
        <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
          3. Kinh phí và tài trợ
        </span>
        <div className="grid pb-5 grid-cols-1 md:grid-cols-2 gap-4 pt-2">
          <div>
            <RequiredLabel>Tổng kinh phí và tài trợ</RequiredLabel>
            <input
              type="number"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.kinhPhi}
              onChange={(e) =>
                setFacultyData({
                  ...facultyData,
                  kinhPhi: Number(e.target.value),
                })
              }
            />
          </div>
          <div>
            <RequiredLabel>Nguồn tài trợ</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.nguonKinhPhi}
              onChange={(e) =>
                setFacultyData({ ...facultyData, nguonKinhPhi: e.target.value })
              }
            />
          </div>
        </div>
      </div>
      <div className="pb-4">
        <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
          4. Nội dung nghiên cứu
        </span>
        <div className="grid pb-5 grid-cols-1 md:grid-cols-1 gap-4 pt-2">
          <div>
            <RequiredLabel>Giới thiệu tổng quan về đề tài</RequiredLabel>
            <textarea
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.mucTieu}
              onChange={(e) =>
                setFacultyData({ ...facultyData, mucTieu: e.target.value })
              }
            />
          </div>
          <div>
            <RequiredLabel>Tính cấp thiết của đề tài</RequiredLabel>
            <textarea
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.ketQuaDuKien}
              onChange={(e) =>
                setFacultyData({ ...facultyData, ketQuaDuKien: e.target.value })
              }
            />
          </div>
        </div>
      </div>
      <div className="space-y-6">
        {/* Nút hành động */}
        <div className="flex justify-end gap-3 pt-6">
          <button
            className="px-6 py-2 text-gray-700 bg-gray-100 rounded-lg hover:bg-gray-200 dark:bg-gray-600 dark:text-gray-200"
            onClick={() => navigate("/giang-vien-nghien-cuu")}
          >
            Hủy
          </button>
          <button
            className="px-6 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 dark:bg-blue-700 dark:hover:bg-blue-800"
            onClick={handleUpdate} // Gọi hàm cập nhật khi nhấn nút
          >
            Cập Nhật
          </button>
        </div>
      </div>
    </div>
  );
}
