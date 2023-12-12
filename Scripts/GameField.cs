using UnityEngine;

public class GameField : MonoBehaviour
{

    public Transform FirstCellPoint;  // ������� ������ ������
    public Vector2 CellSize;          // ������ ������ (�� X � Y)
    public int CellsCount = 100;      // ����� ���������� ����� �� ������� ����
    public int CellsInRow = 10;       // ���������� ����� � ����� ����

    private Vector2[] _cellsPositions; // ������ �� ������� ������ ������
    private Vector2[][] _cellsPositions2; // ������ �� ������� ������ ������

    public void FillCellsPositions()
    {
        _cellsPositions = new Vector2[CellsCount];// ������ ������ � ��������, ������ ������ ���������� �����

        bool right = true;                            // ������� ����������, ������� �����������, ��� ��������� ����� ������ (��� ����� ����������� ������ � �����)
        _cellsPositions[0] = FirstCellPoint.position; // ������ ������� ������ ������ � ������� ������ �������� ������� ������ ������

        // �������� �� ������ ������, ������� �� ������
        for (int i = 1; i < _cellsPositions.Length; i++)
        {
            bool needUp = i % CellsInRow == 0;  // �����, ����� �� ����������� �� ����� ��� �����

            // ���� ����� ����������� �� ����� ���:
            if (needUp)
            {
                right = !right;  // ������ ����������� �������� �� ���������������

                // ������� ������ ���������� ���� �������� �� ������ ����� ������ �����
                _cellsPositions[i] = _cellsPositions[i - 1] + Vector2.up * CellSize.y;
            }
            else    // ���� �� ����� ����������� �� ����� ���:
            {
                // ���������� ���� �������� �� ����������� � ����������� �� ����������� ��������
                float xSign = right ? 1 : -1;

                // �������� �� ����������� ����� ������ ����� ������, ���������� �� ���� ��������
                float deltaX = xSign * CellSize.x;

                // ������� ������ ������������, ����� �� ������� � �� ��������� �������� �� �����������
                _cellsPositions[i] = _cellsPositions[i - 1] + Vector2.right * deltaX;
            }
        }

        /*for (int y = 0; y <= 10; y++)
        {
          _cellsPositions[x][y] = _cellsPositions[x][y] + y*Vector2.up * CellSize.y;
          for (int x = 1; x <= 10; x++)
          {
            // ���������� ���� �������� �� ����������� � ����������� �� ����������� ��������
            int xSign = right ? 1 : -1;

            // �������� �� ����������� ����� ������ ����� ������, ���������� �� ���� ��������
            float deltaX = xSign * CellSize.x;
            _cellsPositions2[x][y] = _cellsPositions2[x + xSign][y] + Vector2.right * deltaX;
          }

          right = !right;
        }*/
    }
}

