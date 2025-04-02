import random

def quick_sort(arr, left, right):
    """
    تقوم بفرز مصفوفة باستخدام خوارزمية الفرز السريع.

    Args:
        arr: المصفوفة المراد فرزها.
        left: مؤشر البداية للجزء المراد فرزه.
        right: مؤشر النهاية للجزء المراد فرزه.
    """
    if left < right:
        # تحسين اختيار العنصر المحوري باستخدام متوسط ثلاثة عناصر
        pivot_index = median_of_three(arr, left, right)
        arr[pivot_index], arr[right] = arr[right], arr[pivot_index]  # وضع العنصر المحوري في النهاية

        partition_index = partition(arr, left, right)

        quick_sort(arr, left, partition_index - 1)
        quick_sort(arr, partition_index + 1, right)


def partition(arr, left, right):
    """
    تقوم بتقسيم المصفوفة حول عنصر محوري.

    Args:
        arr: المصفوفة المراد تقسيمها.
        left: مؤشر البداية للجزء المراد تقسيمه.
        right: مؤشر النهاية للجزء المراد تقسيمه.

    Returns:
        فهرس العنصر المحوري بعد التقسيم.
    """
    pivot = arr[right]
    i = left - 1

    for j in range(left, right):
        if arr[j] <= pivot:
            i += 1
            arr[i], arr[j] = arr[j], arr[i]  # تبديل العناصر

    arr[i + 1], arr[right] = arr[right], arr[i + 1]  # تبديل العنصر المحوري
    return i + 1


def median_of_three(arr, left, right):
    """
    تحسب متوسط ثلاثة عناصر (العنصر الأول والأوسط والأخير).

    Args:
        arr: المصفوفة.
        left: مؤشر البداية.
        right: مؤشر النهاية.

    Returns:
        فهرس العنصر الأوسط بعد ترتيب العناصر الثلاثة.
    """
    mid = (left + right) // 2
    if arr[left] > arr[mid]:
        arr[left], arr[mid] = arr[mid], arr[left]
    if arr[left] > arr[right]:
        arr[left], arr[right] = arr[right], arr[left]
    if arr[mid] > arr[right]:
        arr[mid], arr[right] = arr[right], arr[mid]
    return mid


if __name__ == "__main__":
    n = int(input())
    arr = list(map(int, input().split()))

    quick_sort(arr, 0, len(arr) - 1)

    print(*arr)  # طباعة المصفوفة مع فصل العناصر بمسافات