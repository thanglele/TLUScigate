import { useNavigate } from "react-router-dom";
import {
  Table,
  TableBody,
  TableCell,
  TableHeader,
  TableRow,
} from "../../ui/table";
import Badge from "../../ui/badge/Badge";
import { FiEye, FiTrash2, FiClock } from "react-icons/fi";
import { useEffect, useState } from "react";
// @ts-ignore
import { fetchNCKHGiangVien, RemoveNCKHGiangVienbyID } from "../../../api/NCKHGiangVienAPI";

type BadgeColor =
  | "primary"
  | "success"
  | "error"
  | "warning"
  | "info"
  | "light"
  | "dark";

interface Faculty {
  id: number;
  tenDeTai: string;
  chuNhiemDeTai: string;
  trangThai: string; // Thay tienDo thành trangThai để khớp với đoạn code bạn cung cấp
  khoa: string;
  ngayBatDau: string;
  ngayKetThuc: string;
}

// Hàm ánh xạ trạng thái với màu sắc
const getStatusColor = (trangThai?: string): string => {
  if (!trangThai) {
    return "default";
  }

  switch (trangThai) {
    case "Đã hoàn thành":
      return "success";
    case "Chờ duyệt":
      return "warning";
    case "Chưa hoàn thành":
      return "error";
    default:
      return "default";
  }
};

export default function FacultyTablesOne() {
  const navigate = useNavigate();

  const handleViewDetail = (id: number) => {
    navigate(`/xem-chi-tiet-giang-vien/${id}`);
  };

  const handleDelete = (id: number) => {
    const confirmDelete = window.confirm(
      "Bạn có muốn xóa đề tài giảng viên này không?"
    );
    if (confirmDelete) {
      console.log("Đã xóa đề tài giảng viên với ID:", id);
      try{
        RemoveNCKHGiangVienbyID(id);
        navigate("/giang-vien-nghien-cuu");
      }
      catch (error){
        console.error("Lỗi xóa: ", error);
      }
    } else {
      console.log("Hủy bỏ xóa đề tài giảng viên với ID:", id);
    }
  };

  const handleClock = (id: number) => {
    console.log("Log: " + id);
    navigate(`/cap-nhat-tien-do-gv/${id}`);
  };

  const [facultyData, setFacultyData] = useState<Faculty[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const loadFacultyData = async () => {
      try {
        const response = await fetchNCKHGiangVien();
        console.log("Fetched Data:", response);

        const data = Array.isArray(response.data) ? response.data : [];
        setFacultyData(data);
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
  }, []);

  if (loading) return <div className="text-gray-500">Đang tải dữ liệu...</div>;
  if (error) return <div className="text-red-500">{error}</div>;

  return (
    <div className="overflow-hidden rounded-xl border border-gray-200 bg-white dark:border-white/[0.05] dark:bg-white/[0.03]">
      <div className="max-w-full overflow-x-auto">
        <div className="min-w-[1102px]">
          <Table>
            <TableHeader className="border-b border-gray-100 dark:border-white/[0.05]">
              <TableRow>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  ID
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  TÊN ĐỀ TÀI
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  CHỦ NHIỆM
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  TRẠNG THÁI
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  KHOA
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  NGÀY BẮT ĐẦU
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  NGÀY KẾT THÚC
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  HÀNH ĐỘNG
                </TableCell>
              </TableRow>
            </TableHeader>

            <TableBody className="divide-y divide-gray-100 dark:divide-white/[0.05]">
              {facultyData.map((faculty) => (
                <TableRow key={faculty.id}>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    {faculty.id}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    {faculty.tenDeTai}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    {faculty.chuNhiemDeTai}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    <Badge
                      size="sm"
                      color={getStatusColor(faculty.trangThai) as BadgeColor}
                    >
                      {faculty.trangThai || "Không xác định"}
                    </Badge>
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {faculty.khoa}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {faculty.ngayBatDau}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {faculty.ngayKetThuc}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400 flex ml-4">
                    <div className="flex items-center gap-2">
                      <button
                        className="text-blue-600 hover:text-blue-900 transition-colors"
                        onClick={() => handleViewDetail(faculty.id)}
                      >
                        <FiEye className="w-4 h-4" />
                      </button>
                      <button
                        className="text-red-600 hover:text-red-900 transition-colors"
                        onClick={() => handleDelete(faculty.id)}
                      >
                        <FiTrash2 className="w-4 h-4" />
                      </button>
                      <button
                        className="text-purple-600 hover:text-purple-900 transition-colors"
                        onClick={() => handleClock(faculty.id)}
                      >
                        <FiClock className="w-4 h-4" />
                      </button>
                    </div>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </div>
      </div>
    </div>
  );
}
