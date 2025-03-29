import { useParams , useNavigate } from "react-router";
import { useEffect, useState } from "react";
// @ts-ignore
import { fetchNCKHGiangVienbyID } from "../../api/NCKHGiangVienAPI";

// src/types/NCKHGiangVien.ts
interface NCKHGiangVien {
    id: number;
    maDeTai: string;
    tenDeTai: string;
    linhVucNghienCuu: string[];
    chuNhiemDeTai: string;
    nganh: string;
    khoa: string;
    maChuNhiem: string;
    hocVi: string;
    hocHam: string;
    ngayBatDau: string;
    ngayKetThuc: string;
    thanhvienthamgia: {
      tenThanhVien: string;
      maThanhVien: string;
      hocVi: string;
      hocHam: string;
      nganh: string;
      khoa: string;
    }[];
    kinhPhi: number;
    trangThai: string;
    nguonKinhPhi: string;
    mucTieu: string;
    ketQuaDuKien: string;
    fileHoanThanh: string;
  }

export default function ViewsFaculty() {
  const navigate = useNavigate();
  const [facultyData, setFacultyData] = useState<NCKHGiangVien | null>(null);
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(true);
  const { id } = useParams<{ id: string }>();

  useEffect(() => {
    const loadFacultyData = async () => {
      try {
        const response = await fetchNCKHGiangVienbyID(Number(id));

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
              readOnly
            />
          </div>
          <div>
            <RequiredLabel>Mã đề tài</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.maDeTai}
              readOnly
            />
          </div>
          <div>
            <RequiredLabel>Lĩnh vực nghiên cứu</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.linhVucNghienCuu}
              readOnly
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
              readOnly
            />
          </div>
          <div>
            <RequiredLabel>Ngành</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.nganh}
              readOnly
            />
          </div>
          <div>
            <RequiredLabel>Khoa</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.khoa}
              readOnly
            />
          </div>
        </div>
      </div>
      {/* THỜI GIAN THỰC HIỆN */}
      <div className="pb-4">
        <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
          2. Thời gian thực hiện
        </span>
        <div className="grid pb-5 grid-cols-1 md:grid-cols-2 gap-4 pt-2">
          <div>
            <RequiredLabel>Ngày bắt đầu</RequiredLabel>
            <input
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.ngayBatDau}
              readOnly
            />
          </div>
          <div>
            <RequiredLabel>Ngày kết thúc dự kiến</RequiredLabel>
            <input
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.ngayKetThuc}
              readOnly
            />
          </div>
        </div>
      </div>
      {/* THỜI GIAN THỰC HIỆN */}
      <div className="pb-4">
        <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
          3. Kinh phí và tài trợ
        </span>
        <div className="grid pb-5 grid-cols-1 md:grid-cols-2 gap-4 pt-2">
          <div>
            <RequiredLabel>Tổng kinh phí và tài trợ</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.kinhPhi}
              readOnly
            />
          </div>
          <div>
            <RequiredLabel>Nguồn tài trợ</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.nguonKinhPhi}
              readOnly
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
              readOnly
            />
          </div>
          <div>
            <RequiredLabel>Tính cấp thiết của đề tài</RequiredLabel>
            <textarea
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData?.ketQuaDuKien}
              readOnly
            />
          </div>
        </div>
      </div>
      <div className="space-y-6">
        {/* Nút hành động */}
        <div className="flex justify-end    pt-6">
          <button
            className="px-6 py-2 text-gray-700 bg-gray-100 rounded-lg hover:bg-gray-200 dark:bg-gray-600 dark:text-gray-200"
            onClick={() => navigate("/giang-vien-nghien-cuu")}
          >
            Hủy
          </button>
        </div>
      </div>
    </div>
  );
}
