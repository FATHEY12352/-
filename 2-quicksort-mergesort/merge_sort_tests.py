def merge_sort(arr):
    """
    تقوم بفرز مصفوفة باستخدام خوارزمية الفرز بالدمج.

    Args:
        arr: المصفوفة المراد فرزها.

    Returns:
        المصفوفة المرتبة.
    """
    n = len(arr)
    temp = [0] * n  # إنشاء مخزن مؤقت واحد فقط بحجم n
    merge_sort_helper(arr, temp, 0, n - 1)
    return arr


def merge_sort_helper(arr, temp, left, right):
    """
    دالة مساعدة لتنفيذ الفرز بالدمج بشكل متكرر.

    Args:
        arr: المصفوفة المراد فرزها.
        temp: المخزن المؤقت.
        left: مؤشر البداية.
        right: مؤشر النهاية.
    """
    if left < right:
        mid = (left + right) // 2

        merge_sort_helper(arr, temp, left, mid)
        merge_sort_helper(arr, temp, mid + 1, right)

        merge(arr, temp, left, mid, right)


def merge(arr, temp, left, mid, right):
    """
    تقوم بدمج جزأين مرتبين من المصفوفة.

    Args:
        arr: المصفوفة الأصلية.
        temp: المخزن المؤقت.
        left: مؤشر البداية للجزء الأيسر.
        mid: مؤشر نهاية الجزء الأيسر.
        right: مؤشر نهاية الجزء الأيمن.
    """
    i = left
    j = mid + 1
    k = left

    # دمج الجزئين المرتبين في المخزن المؤقت
    while i <= mid and j <= right:
        if arr[i] <= arr[j]:
            temp[k] = arr[i]
            i += 1
        else:
            temp[k] = arr[j]
            j += 1
        k += 1

    # إضافة أي عناصر متبقية من الجزء الأيسر
    while i <= mid:
        temp[k] = arr[i]
        i += 1
        k += 1

    # إضافة أي عناصر متبقية من الجزء الأيمن
    while j <= right:
        temp[k] = arr[j]
        j += 1
        k += 1

    # نسخ العناصر المرتبة من المخزن المؤقت إلى المصفوفة الأصلية
    for i in range(left, right + 1):
        arr[i] = temp[i]


if __name__ == "__main__":
    n = int(input())
    arr = list(map(int, input().split()))

    sorted_arr = merge_sort(arr)

    print(*sorted_arr)  # طباعة المصفوفة مع فصل العناصر بمسافات