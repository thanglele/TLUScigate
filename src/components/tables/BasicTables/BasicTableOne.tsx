import {
  Table,
  TableBody,
  TableCell,
  TableHeader,
  TableRow,
} from "../../ui/table";

import Badge from "../../ui/badge/Badge";
import { FiEye, FiEdit, FiTrash2 } from "react-icons/fi";

interface Faculty {
  id: number;
  name: string;
  email: string;
  status: string;
  faculty: string;
  major: string;
  joinedDate: string;
}

// Define the table data using the interface
const tableData: Faculty[] = [
  {
    id: 1,
    name: "Ngô Minh Trung",
    email: "ngominhtrung@tlu.edu.vn",
    status: "Đang làm việc",
    faculty: "Công nghệ Thông tin",
    major: "Khoa học Máy tính",
    joinedDate: "15/08/2020"
  },
  {
    id: 2,
    name: "Nguyễn Lê Đức",
    email: "nguyenleduc@tlu.edu.vn",
    status: "Nghỉ hưu",
    faculty: "Kinh tế",
    major: "Quản trị Kinh doanh",
    joinedDate: "20/05/2022"
  },
  {
    id: 3,
    name: "Ngô Bá Trường",
    email: "ngominhtrung@tlu.edu.vn",
    status: "Đang làm việc",
    faculty: "Công nghệ Thông tin",
    major: "Khoa học Máy tính",
    joinedDate: "15/08/2020"
  },
  {
    id: 4,
    name: "Nguyễn Văn Đạt",
    email: "nguyenleduc@tlu.edu.vn",
    status: "Nghỉ hưu",
    faculty: "Kinh tế",
    major: "Quản trị Kinh doanh",
    joinedDate: "20/05/2022"
  },
  {
    id: 5,
    name: "Ngô Bá Minh",
    email: "ngominhtrung@tlu.edu.vn",
    status: "Đang làm việc",
    faculty: "Công nghệ Thông tin",
    major: "Khoa học Máy tính",
    joinedDate: "15/08/2020"
  },
];

// VIET CHI TIET SAU
const handleViewDetail = (id: number) => {
  console.log('Xem chi tiết giảng viên:', id);
};

const handleEdit = (id: number) => {
  console.log('Sửa thông tin giảng viên:', id);
};

const handleDelete = (id: number) => {
  console.log('Xóa giảng viên:', id);
};

export default function BasicTableOne() {
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

            {/* Table Body */}
            <TableBody className="divide-y divide-gray-100 dark:divide-white/[0.05]">
              {tableData.map((faculty) => (
                <TableRow key={faculty.id}>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    {faculty.id}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    {faculty.name}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    {faculty.email}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    <Badge
                      size="sm"
                      color={
                        faculty.status === "Đang làm việc"
                          ? "success"
                          : faculty.status === "Nghỉ hưu"
                            ? "warning"
                            : "error"
                      }
                    >
                      {faculty.status}
                    </Badge>
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {faculty.faculty}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {faculty.major}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {faculty.joinedDate}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    <div className="flex items-center gap-2">
                      {/* Nút Xem chi tiết */}
                      <button
                        className="text-blue-600 hover:text-blue-900 transition-colors"
                        onClick={() => handleViewDetail(faculty.id)}
                      >
                        <FiEye className="w-4 h-4" />
                      </button>

                      {/* Nút Sửa */}
                      <button
                        className="text-green-600 hover:text-green-900 transition-colors"
                        onClick={() => handleEdit(faculty.id)}
                      >
                        <FiEdit className="w-4 h-4" />
                      </button>

                      {/* Nút Xóa */}
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
