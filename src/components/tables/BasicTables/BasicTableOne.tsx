// src/components/tables/FacultyTables/BasicTableOne.tsx
import { useState, useEffect } from "react";
import {
  Table,
  TableBody,
  TableCell,
  TableHeader,
  TableRow,
} from "../../ui/table";
import Badge from "../../ui/badge/Badge";
import { FiEye, FiEdit, FiTrash2 } from "react-icons/fi";
import { fetchLectureData } from "../../../api/LectureAPI";

interface Faculty {
  maGV: string;
  hoTen: string;
  email: string;
  hocVi: string;
  chucVu: string;
  trangThai: string;
  chuyenNganh: string;
  gioiTinh: string;
  diaChi: string;
  soDienThoai: string;
  ngaySinh: string;
  ghiChu: string;
  id: number;
}

const handleViewDetail = (id: number) => {
  console.log(`Xem chi tiết giảng viên: ${id}`);
};

const handleEdit = (id: number) => {
  console.log("Sửa thông tin giảng viên:", id);
};

const handleDelete = (id: number) => {
  console.log("Xóa giảng viên:", id);
};

export default function BasicTableOne() {
  const [facultyData, setFacultyData] = useState<Faculty[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    // Thêm từ khóa async vào đây
    const loadFacultyData = async () => {
      try {
        const data = await fetchLectureData();
        setFacultyData(data);
      } catch (err) {

        setError(
          err.message || "Không thể tải dữ liệu từ API. Vui lòng thử lại sau!"
        );
        console.error(err);
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
                  <p className="text-lg">#</p>
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  HỌ VÀ TÊN
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  EMAIL
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
                  CHUYÊN NGÀNH
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  NGÀY VÀO
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
                    {faculty.maGV}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    {faculty.hoTen}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    {faculty.email}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    <Badge
                      size="sm"
                      color={
                        faculty.trangThai === "Đang làm việc"
                          ? "success"
                          : faculty.trangThai === "Nghỉ hưu"
                          ? "warning"
                          : "error"
                      }
                    >
                      {faculty.trangThai}
                    </Badge>
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {faculty.chucVu}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {faculty.chuyenNganh}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {faculty.ngaySinh}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    <div className="flex items-center gap-2">
                      <button
                        className="text-blue-600 hover:text-blue-900 transition-colors"
                        onClick={() => handleViewDetail(faculty.id)}
                      >
                        <FiEye className="w-4 h-4" />
                      </button>
                      <button
                        className="text-green-600 hover:text-green-900 transition-colors"
                        onClick={() => handleEdit(faculty.id)}
                      >
                        <FiEdit className="w-4 h-4" />
                      </button>
                      <button
                        className="text-red-600 hover:text-red-900 transition-colors"
                        onClick={() => handleDelete(faculty.id)}
                      >
                        <FiTrash2 className="w-4 h-4" />
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
