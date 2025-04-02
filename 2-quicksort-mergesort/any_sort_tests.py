def heapify(arr, n, i):
    """
    تقوم ببناء الكومة الثنائية (binary heap) الفرعية ذات الجذر i.
    """
    largest = i  # تهيئة الجذر كأكبر عنصر
    left = 2 * i + 1  # الابن الأيسر
    right = 2 * i + 2  # الابن الأيمن

    # إذا كان الابن الأيسر أكبر من الجذر
    if left < n and arr[i] < arr[left]:
        largest = left

    # إذا كان الابن الأيمن أكبر من أكبر عنصر حتى الآن
    if right < n and arr[largest] < arr[right]:
        largest = right

    # إذا لم يكن الجذر هو أكبر عنصر
    if largest != i:
        # تبديل الجذر مع أكبر عنصر
        arr[i], arr[largest] = arr[largest], arr[i]

        # استدعاء heapify بشكل متكرر على الكومة الفرعية المتأثرة
        heapify(arr, n, largest)


def heap_sort(arr):
    """
    تقوم بفرز مصفوفة باستخدام خوارزمية فرز الكومة.
    """
    n = len(arr)

    # بناء الكومة الثنائية القصوى (max heap)
    for i in range(n // 2 - 1, -1, -1):
        heapify(arr, n, i)

    # استخراج العناصر واحدًا تلو الآخر من الكومة
    for i in range(n - 1, 0, -1):
        # تبديل العنصر الجذر (أكبر عنصر) مع العنصر الأخير
        arr[i], arr[0] = arr[0], arr[i]

        # استدعاء heapify على الكومة المصغرة
        heapify(arr, i, 0)


if __name__ == "__main__":
    n = int(input())
    arr = list(map(int, input().split()))

    heap_sort(arr)

    print(*arr)