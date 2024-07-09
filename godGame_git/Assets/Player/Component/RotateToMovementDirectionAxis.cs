using UnityEngine;

public class RotateToMovementDirectionAxis : MonoBehaviour
{
    // �ő�̉�]�p���x[deg/s]
    [SerializeField] private float _maxAngularSpeed = Mathf.Infinity;

    // �i�s�����Ɍ����̂ɂ����邨���悻�̎���[s]
    [SerializeField] private float _smoothTime = 0.1f;

    // �I�u�W�F�N�g�̐���
    [SerializeField] private Vector3 _forward = Vector3.forward;

    // �I�u�W�F�N�g�̏����
    [SerializeField] private Vector3 _up = Vector3.up;

    // ��]��
    [SerializeField] private Vector3 _axis = Vector3.up;

    private Transform _transform;

    // �O�t���[���̃��[���h�ʒu
    private Vector3 _prevPosition;

    private float _currentAngularVelocity;

    private void Start()
    {
        _transform = transform;

        _prevPosition = _transform.position;
    }

    private void Update()
    {
        // ���݃t���[���̃��[���h�ʒu
        var position = _transform.position;

        // �ړ��ʂ��v�Z
        var delta = position - _prevPosition;

        // ����Update�Ŏg�����߂̑O�t���[���ʒu�X�V
        _prevPosition = position;

        // �Î~���Ă����Ԃ��ƁA�i�s���������ł��Ȃ����߉�]���Ȃ�
        if (delta == Vector3.zero)
            return;

        // ��]�␳�v�Z
        var offsetRot = Quaternion.Inverse(Quaternion.LookRotation(_forward, _up));

        // ���[���h��Ԃ̑O���x�N�g���擾
        var forward = _transform.TransformDirection(_forward);

        // ��]���Ɛ����ȕ��ʂɓ��e�����x�N�g���v�Z
        var projectFrom = Vector3.ProjectOnPlane(forward, _axis);
        var projectTo = Vector3.ProjectOnPlane(delta, _axis);

        // ������̊p�x�������߂�
        var diffAngle = Vector3.Angle(projectFrom, projectTo);

        // ���݃t���[���ŉ�]����p�x�̌v�Z
        var rotAngle = Mathf.SmoothDampAngle(
            0,
            diffAngle,
            ref _currentAngularVelocity,
            _smoothTime,
            _maxAngularSpeed
        );

        // ������ł̉�]�̊J�n�ƏI�����v�Z
        var lookFrom = Quaternion.LookRotation(projectFrom);
        var lookTo = Quaternion.LookRotation(projectTo);

        // ���݃t���[���ɂ������]���v�Z
        var nextRot = Quaternion.RotateTowards(lookFrom, lookTo, rotAngle) * offsetRot;

        // �I�u�W�F�N�g�̉�]�ɔ��f
        _transform.rotation = nextRot;
    }
}